using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StarterProject.ViewModel
{
    class CalendarViewModel 
    {
        public SelectionRange SelectedRange { get; set; }

        public CalendarViewModel()
        {
            SelectedRange = new SelectionRange();
            SelectedRange.StartDate = new DateTime(2019, 02, 10);
            SelectedRange.EndDate = new DateTime(2019, 02, 20);
        }

    }
}
