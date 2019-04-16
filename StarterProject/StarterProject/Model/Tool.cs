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

        public List<Tool> GetSpeakers()
        {
            List<Tool> tools = new List<Tool>()
            {
                new Tool(){ToolDescription = "Hammer - wie neu!", ToolLocation="Mannheim", ToolPrice="1 € pro Tag" ,ToolImage="hammer.png", ToolLat=8.47955, ToolLong=49.49671},
                new Tool(){ToolDescription = "Hammer - top Zustand", ToolLocation="Mannheim", ToolPrice="1,50 € pro Tag" ,ToolImage="hammer.png", ToolLat=8.48955, ToolLong=49.69671},
                new Tool(){ToolDescription = "Hammer", ToolLocation="Heidelberg", ToolPrice="1 € pro Tag" ,ToolImage="hammer.png", ToolLat= 8.69079, ToolLong=49.40768},
                new Tool(){ToolDescription = "Kostenloser Hammer", ToolLocation="Mannheim", ToolPrice="kostenlos" ,ToolImage="hammer.png", ToolLat=8.47978, ToolLong=49.49632},

                


            };
            return tools;
        }

    }
}
