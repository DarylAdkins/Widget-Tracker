using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Widget_Tracker.Models.ViewModels
{
    public class EditLotsViewModel
    {
        public List<SelectListItem> Lines { get; set; }

        public Lot Lot { get; set; }

    }
}
