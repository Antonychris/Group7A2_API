using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group7A2_API.Controllers.Models
{
    public class Group7A2Context : DbContext
    {
        public Group7A2Context(DbContextOptions<Group7A2Context>options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
