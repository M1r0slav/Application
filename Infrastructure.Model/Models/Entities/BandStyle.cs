namespace Infrastructure.Models
{
    public class BandStyle // Composite Key
    {
        public int BandId { get; set; } 
        public virtual Band Band {get;set;}
        public int MusicStyleId { get; set; }
        public virtual MusicStyle MusicStyle { get; set; }
    }
}
