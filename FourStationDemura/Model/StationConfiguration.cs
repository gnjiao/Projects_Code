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

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("SlaveGroup", IsNullable = false)]
        public SlaveGroup[] SlaveGroups { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ControlCard", IsNullable = false)]
        public ControlCard[] ControlCards { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("IOCard", IsNullable = false)]
        public IOCard[] IOCards { set; get; }
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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SlaveGroup
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Slave")]
        public Slave[] Slaves { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Slave
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ip { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int port { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool enable { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ControlCard
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Axis")]
        public Axis[] Axises { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int cardno { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Axis
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WorkPosition")]
        public double[] WorkPosition { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int num { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double step { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Lead { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Speed { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double MaxLimitmm { set; get; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class IOCard
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OutputPort")]
        public OutputPort[] OutputPorts { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InputPort")]
        public InputPort[] InputPorts { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int cardno { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
        
        /// <summary>
        /// 获取IO口
        /// </summary>
        /// <typeparam name="T">Inputport或者OutputPort</typeparam>
        /// <param name="condition">IO口的no或者name</param>
        /// <returns>满足条件的Inputport或者OutputPort</returns>
        public T GetPort<T>(object condition)
        {
            object[] arrayObj = null;
            //先判断查找的是输入端口还是输出端口
            if (typeof(T) == typeof(OutputPort))
            {
                if (condition is int)
                {
                    arrayObj = (object[])(OutputPorts.Where(x => x.bitno == (int)condition));

                }
                else if (condition is string)
                {
                    arrayObj = (object[])(OutputPorts.Where(x => x.name == (string)condition));
                }

                //不满足条件 arrayObj还是为null
            }
            else if (typeof(T) == typeof(InputPort))
            {
                if (condition is int)
                {
                    arrayObj = InputPorts.Where(x => x.bitno == (int)condition).ToArray();

                }
                else if (condition is string)
                {
                    arrayObj = InputPorts.Where(x => x.name == (string)condition).ToArray();
                }
                //不满足条件 arrayObj还是为null

            }

            if (arrayObj == null||arrayObj.Length==0) //输入的T不符合要求arrayObj为null，condition没找到arrayObj长度为0，两种都是不满足要求
            {
                return default(T);  
            }

            if (arrayObj.Length > 1)
            {
                throw new Exception("Two or more ports was set to be port \""+condition.ToString()+" !!!");
            }

            return (T)arrayObj[0];
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OutputPort
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int bitno { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class InputPort
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int bitno { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public EventTrigger EventTrigger { set; get; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description { set; get; }
    }
    public enum EventTrigger
    {
        LogicLow=0,
        LogicHigh=1,
        NegativeEdge=2,
        PositiveEdge=3
    }



}
