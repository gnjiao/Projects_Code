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
                if (Instance==null)
                {
                    Instance = XmlHelper.XmlDeserialize<StationConfiguration>("./Configuration/StationConfiguration.xml");
                }
            }
            return Instance;
        }

        #endregion

        /// <remarks/>
        public byte PanelNum { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Station")]
        public Station[] Stations { set; get; }
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


}
