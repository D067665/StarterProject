using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model
{
    class Availability
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string toolRef { get; set; }
        public string avUid { get; set; }
        public Tool toolName { get; set; }
    }
}
