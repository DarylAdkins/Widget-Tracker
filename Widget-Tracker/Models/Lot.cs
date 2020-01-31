using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models
{
    public class Lot
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        public int LineId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Lot Owner")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Manufacturing Line")]
        public Line AssociatedLine { get; set; }

        public List<LotProcess> LotProcesses { get; set; } = new List<LotProcess>();

    }
}
