using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Brewery
    {
        public int Brewery_id { get; set; }
        public string Name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string History { get; set; }
        public bool Active { get; set; }
        public string Brewery_img { get; set; }
        public int? User_id { get; set; }

        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}

