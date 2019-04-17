using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model
{
    public class Tool
    {
        public string ToolDescription { get; set; }
        public string ToolLocation { get; set; }
        public string ToolPrice { get; set; }
        public string ToolImage { get; set; }
        public double ToolLong { get; set; }
        public double ToolLat { get; set; }
        public string OwnerPhone { get; set; }

        public List<Tool> GetSpeakers()
        {
            List<Tool> tools = new List<Tool>()
            {
                new Tool(){ToolDescription = "Hammer - wie neu!", ToolLocation="Mannheim", ToolPrice="1 € pro Tag" ,ToolImage="hammer.png", ToolLat= 49.49671 , ToolLong=8.47955, OwnerPhone="+496224567867"},
                new Tool(){ToolDescription = "Hammer - top Zustand", ToolLocation="Mannheim", ToolPrice="1,50 € pro Tag" ,ToolImage="hammer.png", ToolLat= 49.69671, ToolLong=8.48955, OwnerPhone="+496224567854"},
                new Tool(){ToolDescription = "Hammer", ToolLocation="Heidelberg", ToolPrice="1 € pro Tag" ,ToolImage="hammer.png", ToolLat=49.40768 , ToolLong=8.69079, OwnerPhone="+496224566767"},
                new Tool(){ToolDescription = "Kostenloser Hammer", ToolLocation="Mannheim", ToolPrice="kostenlos" ,ToolImage="hammer.png", ToolLat=49.49632 , ToolLong=8.47978, OwnerPhone="+496224567777"},

                


            };
            return tools;
        }

    }
}
