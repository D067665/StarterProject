using System;
using System.Collections.Generic;
using System.Text;

using StarterProject.Model;

namespace StarterProject.ViewModel
{
    public class ToolViewModel
    {
        public List<Tool> Tools { get; set; }

        public ToolViewModel()
        {
            Tools = new Tool().GetSpeakers();
        }
    }
}
