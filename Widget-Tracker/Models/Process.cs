using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models
{
    public class Process
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the process description to 55 characters")]
        public string Description { get; set; }

        public int LineId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; set; }

        public Line AssociatedLine { get; set; }


    }
}
