using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model

{
    //Class for Availabilities from BackEnd, show when a tool is booked
    public class Availability
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string toolRef { get; set; }
        public string avUid { get; set; }
        public Tool toolName { get; set; }
    }
}
