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
        public int Name { get; set; }

        public List<Process> Processes { get; set; } = new List<Process>();

    }
}
