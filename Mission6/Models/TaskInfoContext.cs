using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskInfoContext : DbContext
    {
        public TaskInfoContext(DbContextOptions<TaskInfoContext> options) : base(options)
        {
            //Leave Blank for now
        }

        //This sets the name of the tables
        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );

            //mb.Entity<Tasks>().HasData(
            //    new Tasks
            //    {
            //        TaskId = 1,
            //        TaskName = "Task1",
                    
            //        Quadrant = 1,
            //        CategoryId = 1

            //    }
    
            //    );
        }
    }
}
