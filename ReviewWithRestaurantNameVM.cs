using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dining.Models
{
    public class ReviewWithRestaurantNameVM
    {
        public string user_name { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public string restaurant_name { get; set; }
    }
}