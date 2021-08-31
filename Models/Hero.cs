


using System.Collections.Generic;

namespace relation.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<HeroPower> Powers { get; set; }

    }
}