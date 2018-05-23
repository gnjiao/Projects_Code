using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Model
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class StationConfiguration
    {

        #region static instance & function
        private static StationConfiguration Instance = null;
        private static object lockobj = new object();
        public static StationConfiguration GetInstance()
        {
            lock (lockobj)
            {
                if (Instance == null)
                {
                    Instance = XmlHelper.XmlDeserialize<StationConfiguration>("./Configuration/StationConfiguration.xml");
                }
            }
            return Instance;
        }

        #endregion

        /// <remarks/>
        public int PanelCountOfStation { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Station")]
        public Station[] Stations { set; get; }

        [System.Xml.Serialization.XmlElementAttribute("SlaveGroup")]
        public SlaveGroup[] SlaveGroups { set; get; }
        [System.Xml.Serialization.XmlElementAttribute("ControlCards")]
        public ControlCards ControlCardsCollection { set; get; }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Station
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string color { set; get; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SlaveGroup
    {
        [System.Xml.Serialization.XmlElementAttribute("Slave")]
        public Slave[] Slaves { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute]
        public string name { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute]
        public string description { set; get; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Slave
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ip { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int port { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool enable { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType =true)]
    public partial class ControlCards
    {
        [System.Xml.Serialization.XmlElementAttribute("ControlCard")]
        public ControlCard[] Cards { set; get; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ControlCard
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double cardno { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
        [System.Xml.Serialization.XmlElementAttribute("Axis")]
        public Axis[] AxisCollection { set; get; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType =true)]
    public class Axis
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int num { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double step { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Lead { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Speed { set; get; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double MaxLimitmm { set; get; }
        public double WorkStation { set; get; }
    }
}
