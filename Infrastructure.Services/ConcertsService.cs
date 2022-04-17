using Infrastructure.Data;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ConcertsService : IConcertsService
    {
        private readonly ApplicationDbContext db;

        public ConcertsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<Concert> GetAllConcerts()
        {
            var concertsFd = db.Concerts
                .Include(x => x.Shows.Where(s => !s.IsDeleted && DateTime.Compare(s.Date , DateTime.UtcNow) > 0).OrderBy(d=>d.Date))
                .Where(c => c.IsDeleted == false).ToArray();
            return concertsFd;
        }
    }
}
