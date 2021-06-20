using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Model
{
    public class Lesson
    {
        public Lesson() { }

        public Lesson(string ownerID, string content, float time)
        {
            OwnerID = ownerID;
            Content = content;
            Time = time;
        }

        private string ownerID;
        private string content;
        private float time;

        public string OwnerID { get { return ownerID; } set { ownerID = value; } }
        public string Content { get { return content;} set { content = value; } }
        public float Time { get { return time; } set { time = value; } }
    }
}
