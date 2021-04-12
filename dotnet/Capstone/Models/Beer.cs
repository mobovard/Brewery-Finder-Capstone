using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Beer
    {
        public int Beer_id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be blank")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image cannot be blank")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Abv cannot be blank")]
        public decimal Abv { get; set; }
        public int? Brewery_id { get; set; }

        [Required(ErrorMessage = "Beer Type cannot be blank")]
        public string Beer_type { get; set; }
        public bool? Active { get; set; }
    }
}
