using PairProgramming.Repositories;

const string policyName = ("AllowAll");
var builder = WebApplication.CreateBuilder(args);

 //Add services to the container.
builder.Services.AddCors(options =>
{
 options.AddPolicy(name: "AllowAll",
       policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
       });
   options.AddPolicy(name: "OnlyGET", policy =>
   {
        policy.AllowAnyOrigin().WithMethods("GET").AllowAnyMethod();
   });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MusicRepository>(new MusicRepository());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
