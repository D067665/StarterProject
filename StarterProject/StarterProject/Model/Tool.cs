using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model
{
    public class Tool
    {
        public string ToolDescription { get; set; }
        public string ToolLocation { get; set; }
        public double ToolPrice { get; set; }
        public string ToolPriceSpan { get; set; }
        public string ToolImage { get; set; }
        public string ToolUid { get; set; }
        public double ToolLong { get; set; }
        public double ToolLat { get; set; }
        public string OwnerPhone { get; set; }
        public DateTime minDateUser { get; set; }
        public DateTime maxDateUser  {get; set; }

    public string CombinedPrice
        {
            get
            {
                return string.Format("{0} - {1}", ToolPrice, ToolPriceSpan);
            }
        }
        public string ToolDatabaseNameSub { get; set; }

        public List<Tool> GetSpeakers()
        {
            List<Tool> tools = new List<Tool>()
            {
                new Tool(){ToolDescription = "Hammer - wie neu!", ToolLocation="Mannheim", ToolPrice=1 , ToolPriceSpan="pro Woche", ToolImage="hammer.png", ToolLat= 49.49671 , ToolLong=8.47955, OwnerPhone="+496224567867", ToolDatabaseNameSub="test"},
                new Tool(){ToolDescription = "Hammer - top Zustand", ToolLocation="Mannheim", ToolPrice=1.50, ToolPriceSpan="pro Tag" ,ToolImage="hammer.png", ToolLat= 49.69671, ToolLong=8.48955, OwnerPhone="+496224567854", ToolDatabaseNameSub="test"},
                new Tool(){ToolDescription = "Hammer", ToolLocation="Heidelberg", ToolPrice=1, ToolPriceSpan="pro Woche" ,ToolImage="hammer.png", ToolLat=49.40768 , ToolLong=8.69079, OwnerPhone="+496224566767", ToolDatabaseNameSub="test"},
                new Tool(){ToolDescription = "Kostenloser Hammer", ToolLocation="Mannheim", ToolPrice=0 ,ToolPriceSpan="pro Woche", ToolImage="hammer.png", ToolLat=49.49632 , ToolLong=8.47978, OwnerPhone="+496224567777", ToolDatabaseNameSub="test"},

                


            };
            return tools;
        }

    }
}
