using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dining.Models
{
    public class Restaurant_Review
    {
        [Key]
        public int Restaurant_Review_Id { get; set; }
        public int restaurant_Id { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        public string comment { get; set; }
    }
}

