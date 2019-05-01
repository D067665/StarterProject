using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model
{
    //necessary to combine Item Sources Availability and Item to display Info from both in ListView HistoryPage
    public class AvailabilityPerTool
    {
        public string ToolDescription { get; set; }
        public string ToolImage { get; set; }
        public string ToolLocation { get; set; }
        public double ToolPrice { get; set; }
        public string ToolPriceSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CombinedPrice
        {
            get
            {
                return string.Format("{0} - {1}", ToolPrice, ToolPriceSpan);
            }
        }
        public string StartToEnd
        {
            get
            {
                return string.Format("{0} - {1}", StartDate.ToString("dd.MM.yyyy"), EndDate.ToString("dd.MM.yyyy"));
            }
        }
    }
}
