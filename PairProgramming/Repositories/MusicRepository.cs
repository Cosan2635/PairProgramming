using PairProgramming.Models;
using System.Security.Cryptography.X509Certificates;

namespace PairProgramming.Repositories
{
    public class MusicRepository
    {
        private List<Music> _musics;
        private int _NextId;
        public MusicRepository()
        {
            _NextId = 1;
            _musics = new List<Music>()
            {
                new Music() { id = 1, title = "moo", artist = "Mohammed", duration = 150, publicationYear = 2022 },
                new Music() { id = 2,title = "hay", artist = "Haydar",duration = 145, publicationYear = 2020}


            };           
        }
        public List<Music> GetAll()
        {
            List<Music> list = new List<Music>();
            return list;
        }
    }
}
