using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Beer
    {
        public int Beer_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Abv { get; set; }
        public int Brewery_id { get; set; }
        public string Beer_type { get; set; }
    }
}
