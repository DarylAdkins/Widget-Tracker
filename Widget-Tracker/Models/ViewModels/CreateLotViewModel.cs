using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models.ViewModels
{
    public class CreateLotViewModel
    {
        
        public List<SelectListItem> Lines { get; set; }

        public Lot Lot { get; set; }

        //public List<Process> lineProcesses = new 
    }
}

