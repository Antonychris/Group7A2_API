using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group7A2_API.Controllers.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        //A category has many posts
        public List<Post> Posts { get; set; }
    }
}
