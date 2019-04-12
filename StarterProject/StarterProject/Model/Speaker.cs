using System;
using System.Collections.Generic;
using System.Text;

namespace StarterProject.Model
{
    public class Speaker
    {
        public string SpeakerName { get; set; }
        public string Topic { get; set; }
        public string ShortDescription { get; set; }
        public string ImageURL { get; set; }

        public List<Speaker> GetSpeakers()
        {
            List<Speaker> speakers = new List<Speaker>()
            {
                new Speaker(){SpeakerName = "Obama", Topic="Trump", ImageURL="hammer.png", ShortDescription="Barack compains about Donald al lot" },
                new Speaker(){SpeakerName = "Merkel", Topic="Physik", ImageURL="hammer.png", ShortDescription="Merkel talks about her studies" },
                new Speaker {SpeakerName = "Lindner", Topic="Himself", ImageURL="hammer.png", ShortDescription="Lindner talks about himself - of course" },


            };
            return speakers;
        }

    }
}
