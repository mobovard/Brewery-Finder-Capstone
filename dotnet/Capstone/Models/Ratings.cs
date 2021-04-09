using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Ratings
    {
        public int Rating_id { get; set; }
        public int Rating { get; set; }
        public string Rating_description { get; set; }
        public int User_id { get; set; }
        public int Beer_id { get; set; }
    }
}
