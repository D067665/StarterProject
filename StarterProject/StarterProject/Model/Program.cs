using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace StarterProject.Model
{
    class Program
    {
        public static void Main(string[] args)
        {
            Tool tool = new Tool()
            {
                ToolDescription = "Hammer - wie neu!",
                ToolLocation = "Mannheim",
                ToolPrice = 1,
                ToolPriceSpan = "pro Woche",
                ToolImage = "hammer.png",
                ToolLat = 49.49671,
                ToolLong = 8.47955,
                OwnerPhone = "+496224567867"
            };

            string strResultJson = JsonConvert.SerializeObject(tool);
            Console.WriteLine(strResultJson);
        }
    }
}
