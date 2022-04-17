using System.Collections.Generic;

namespace Infrastructure.Models
{

    public class Concert : BaseEntity<int>
    {
        public Concert()
        {
            Shows = new HashSet<ConcertDate>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterAddress { get; set; }
 
        public int BandId { get; set; }
        public virtual Band Band { get; set; }
        public virtual ICollection<ConcertDate> Shows { get; set; }
    }
}
