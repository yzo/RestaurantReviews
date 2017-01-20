using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dining.Models
{
    public class Restaurant
    {
        [Key]
        public int restaurant_Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        public virtual IList<Restaurant_Review> reviews { get; set; }
    }

}