using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models
{
    public class Line
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the manufacturing line description to 55 characters")]
        public string Description { get; set; }

        public bool Archived { get; set; }

       

        public List<Process> Processes { get; set; } = new List<Process>();

    }
}
