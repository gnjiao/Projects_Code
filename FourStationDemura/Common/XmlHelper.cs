using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Common
{
    public class XmlHelper
    {
        public static T XmlDeserialize<T>(string fileName)
        {
            object obj = new object();

            XmlSerializer xsl = new XmlSerializer(typeof(T));

            using (FileStream fs=new FileStream (fileName,FileMode.Open,FileAccess.Read,FileShare.None))
            {
                obj = xsl.Deserialize(fs);
            }

            return (T)obj;
        }
    }
}
