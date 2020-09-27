using System;
using System.Collections.Generic;
using System.Text;

namespace PUL.GS.Models
{
    public class ResponseNotification
    {
        public string id { get; set; }
        public int recipients { get; set; }
        public string external_id { get; set; }
    }
}
