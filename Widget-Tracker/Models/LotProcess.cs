using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models
{
    public class LotProcess
    {
        public int Id { get; set; }

        public int LotId { get; set; }

        public int ProcessId { get; set; }

        
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Time lot started")]
        public DateTime? TimeIn { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Time lot finished")]
        public DateTime? TimeOut { get; set; }

        public Lot Lot { get; set; }

        public Process Process { get; set; }



    }
}
