using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CDDA.Models
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Builds
    {
        [XmlElement(ElementName = "build")]
        public List<Build> BuildList { get; set; }
    }

    public partial class Run
    {
        [XmlElement(ElementName = "fullDisplayName")]
        public string FullDisplayName { get; set; }
        [XmlElement(ElementName = "result")]
        public string Result { get; set; }
    }


    public partial class Changeset
    {
        [XmlElement(ElementName = "item")]
        public List<Item> ItemList { get; set; }
    }

    public partial class Item
    {
        [XmlElement(ElementName = "msg")]
        public string Msg { get; set; }

        public string  GitHashNumber { get; set; }
    }

    public partial class Build
    {
        [XmlElement(ElementName = "building")]
        public bool Building { get; set; }

        [XmlElement(ElementName = "number")]
        public int Number { get; set; }

        [XmlElement(ElementName = "result")]
        public string Result { get; set; }

        [XmlElement(ElementName = "timestamp")]
        public ulong Timestamp { get; set; }

        [XmlElement(ElementName = "changeSet")]
        public List<Changeset> ChangesetList { get; set; }

        [XmlElement(ElementName = "run")]
        public List<Run> RunList { get; set; }
    }
}
