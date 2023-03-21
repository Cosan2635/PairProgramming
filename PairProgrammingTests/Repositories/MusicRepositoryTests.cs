using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairProgramming.Models;
using PairProgramming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PairProgramming.Repositories.Tests
{
    [TestClass()]
    public class MusicRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
         MusicRepository repo = new MusicRepository();
         List<Music?> musics= repo.GetAll("moo", 150, "Muhammed");
         Assert.IsNotNull(musics);
            Assert.IsTrue(musics.Count() >= 0);
        }
    }
}