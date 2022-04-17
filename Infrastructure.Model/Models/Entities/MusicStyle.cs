using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class MusicStyle : BaseEntity<int>
    {
        public string Name { get; set; }    //Rock
        //
        public string Description { get; set; }
    }
}
