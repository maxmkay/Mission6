using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class Tasks
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        //This builds a foreign key relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }
    }
}
