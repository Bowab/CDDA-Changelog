using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDDA.Models
{
    public class Changelog
    {
        public bool Building { get; set; }
        public int Number { get; set; }
        public DateTime Timestamp { get; set; }
        public List<string> MsgList { get; set; }
        public List<Version> VersionList { get; set; }

    }

    public class Version
    {
        public string FullDisplayName { get; set; }
        public bool Result { get; set; }
    }
}
