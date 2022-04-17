using Infrastructure.Data;
using Infrastructure.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Infrastructure.Services
{
    public class DBSeeder
    {
        private static bool isChecked = false;

        private readonly ApplicationDbContext db;

        public DBSeeder(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool HasBands()
        {
            return db.Bands.Any();
        }

        public void Seed()
        {
            if (!isChecked && !HasBands())
            {
                var bands = ParseTextToObjects<Band>(ReadDataJson("bands")) ;
                var musicStyles = ParseTextToObjects<MusicStyle>(ReadDataJson("musicStyles"));
                
                var bandStyles = ParseTextToObjects<BandStyle>(ReadDataJson("bandStyles"));
                var concerts = ParseTextToObjects<Concert>(ReadDataJson("concerts"));
                var cocertDates = ParseTextToObjects<ConcertDate>(ReadDataJson("concertDates"));

                RemoveKeys(bands);
                RemoveKeys(concerts);               
                RemoveKeys(musicStyles);
                RemoveKeys(cocertDates);

                db.AddRange(bands);
                db.AddRange(musicStyles);
                db.SaveChanges();

                db.AddRange(concerts);
                db.AddRange(bandStyles);
                db.SaveChanges();
                db.AddRange(cocertDates);
                db.SaveChanges();
            }
            isChecked = true;
        }

        private void RemoveKeys<T>(ICollection<BaseEntity<T>> entities)
        {
            foreach (var entity in entities)
            {
                entity.SetKeyDefault();
            }
        }
        public static string ReadDataJson(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "../Infrastructure.Services/SeederDB/data.jsons/", fileName + ".json");
            return File.ReadAllText(path);
        }

        public static T[] ParseTextToObjects<T>(string data)
        {
            return JsonConvert.DeserializeObject<T[]>(data);
        }

    }
}
