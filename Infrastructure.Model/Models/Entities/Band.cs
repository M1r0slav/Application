using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Infrastructure.Models
{
    public class Band : BaseEntity<int>
    {
        public Band()
        {
            Concerts = new HashSet<Concert>();
            Styles = new HashSet<BandStyle>();
        }
        public string BandCoverJPG { get; set; }

        public string Name { get; set; }
        public string Participants { get; set; } //"Toni Storaro-Singer|Aleks Alekseevish Aleksov-Bass Guitar very good"
        public string Description { get; set; }

        [NotMapped]
        public virtual List<Musician> Musicians => Participants
            .Split("|", System.StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split("-", System.StringSplitOptions.RemoveEmptyEntries))
            .Select(x => new Musician(x[0], x[1])).ToList();

        public virtual ICollection<Concert> Concerts { get; set; }
        public virtual ICollection<BandStyle> Styles { get; set; }
    }
}
