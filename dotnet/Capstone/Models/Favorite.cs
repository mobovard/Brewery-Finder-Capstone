using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Favorite
    {
        public int Favorite_id { get; set; }
        public int User_id { get; set; }
        public int Brewery_id { get; set; }
    }
}
