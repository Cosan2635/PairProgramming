using Microsoft.AspNetCore.Mvc;
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
                new Music() { id =_NextId++, title = "moo", artist = "Muhammed", duration = 150, publicationYear = 2022 },
                new Music() { id = _NextId++ ,title = "hay", artist = "Haydar",duration = 145, publicationYear = 2020},
                new Music() { id =_NextId++, title = "mookk", artist = "Muhammed", duration = 150, publicationYear = 2022 },
                new Music() { id = _NextId++ ,title = "hayhh", artist = "Haydar",duration = 145, publicationYear = 2020}
            };
        }


        public List<Music> GetAll(int? amount = null ,string ? title = null, int? duration = null, string? artist = null )
        {
            List<Music> list = new List<Music>();
            if (title != null)
            {
                list = list.FindAll(l=>l.title != null && l.title.ToLower().StartsWith(title));
            }

            if (duration != null)
            {    int passedDuration = (int) duration;
                list = list.Take(passedDuration).ToList();
                //list = list.FindAll(l => l.duration != null && l.duration  == duration);
            }
            if (artist != null)
            {
                list = list.FindAll(l => l.artist != null && l.artist.ToLower().StartsWith(artist));
            }
            if( amount != null)
            {
                int passedAmount = (int) amount;
                list = list.Take(passedAmount).ToList();
            }
           

            return list;
        }

         public Music? GetById(int id)
        {
            return _musics.Find(m=> m.id == id);
        }
        
        public Music? AddMusic( Music newmusic )
        {
            newmusic.id = _NextId++;
            _musics.Add(newmusic);
            return newmusic;
        }

        public Music updateMusic(int id, Music updates)
        {
            Music foundmusic = GetById(id);
            if(foundmusic == null)
            {
                return null;
            }
            foundmusic.title = updates.title;
            foundmusic.duration = updates.duration;
            foundmusic.artist = updates.artist;
            
                return foundmusic;
        }

        public Music? Delete(int id)
        {
            Music? foundmusic = GetById(id);
            if(foundmusic == null)
            {
                return null;

            }
            _musics.Remove(foundmusic);
            return foundmusic;
        }
    }
}
