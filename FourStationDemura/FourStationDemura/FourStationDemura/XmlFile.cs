using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FourStationDemura
{
    public class XmlFile
    {
        /// <summary>
        /// 创建用户Xml文件，并生成admin账户
        /// </summary>
        /// <param name="path"></param>
        public static void CreateXmlFile(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>  
            XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            //创建根节点  
            XmlNode rootNode = xmlDoc.CreateElement("Users");

            //创建子节点  
            XmlNode userNode = xmlDoc.CreateElement("user");
            //创建一个属性  
            XmlAttribute id = xmlDoc.CreateAttribute("id");
            id.Value = Guid.NewGuid().ToString();

            XmlAttribute name = xmlDoc.CreateAttribute("userName");
            name.Value = "admin";

            XmlAttribute dept = xmlDoc.CreateAttribute("dept");
            dept.Value = "管理员";

            XmlAttribute password = xmlDoc.CreateAttribute("password");
            password.Value = "123456";

            XmlAttribute workNumber = xmlDoc.CreateAttribute("workNumber");
            workNumber.Value = "admin";

            XmlAttribute permissions = xmlDoc.CreateAttribute("permissions");
            permissions.Value = "";

            userNode.Attributes.Append(id);
            userNode.Attributes.Append(name);
            userNode.Attributes.Append(dept);
            userNode.Attributes.Append(password);
            userNode.Attributes.Append(workNumber);
            userNode.Attributes.Append(permissions);

            rootNode.AppendChild(userNode);

            //附加根节点  
            xmlDoc.AppendChild(rootNode);

            xmlDoc.InsertBefore(Declaration, xmlDoc.DocumentElement);

            //加密保存Xml文档  
            EncryptFile(xmlDoc, path);

            //xmlDoc.Save(path);

            //将用户信息从xml文件中读出来用dt保存
            Global.DtUser = XmlToDataTable(path);
        }

        /// <summary>
        /// 删除xml节点
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteXmlNode(string path, string id)
        {
            bool f = false;

            try
            {
                XmlDocument xmlDoc = DecryptFile(path);

                XmlNode rootNode = xmlDoc.SelectSingleNode("Users");

                foreach (XmlNode node in rootNode.SelectNodes("user"))
                {
                    if (id == node.Attributes["id"].Value)
                    {
                        rootNode.RemoveChild(node);
                        break;
                    }
                }

                //加密保存Xml文档  
                EncryptFile(xmlDoc, path);

                //将用户信息从xml文件中读出来用dt保存
                Global.DtUser = XmlToDataTable(path);

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }

        /// <summary>
        /// 修改xml节点信息
        /// </summary>
        /// <param name="path">文件保存路径</param>
        /// <param name="userId">用户ID</param>
        /// <param name="dictAttribute">要修改的属性集合，Key=属性名，Value=修改值</param>
        /// <returns></returns>
        public static bool UpdateXmlNode(string path, string userId, Dictionary<string, string> dictAttribute)
        {
            bool f = false;

            try
            {
                XmlDocument xmlDoc = DecryptFile(path);

                XmlNode rootNode = xmlDoc.SelectSingleNode("Users");

                foreach (XmlNode node in rootNode.SelectNodes("user"))
                {
                    var id = node.Attributes["id"].Value;

                    if (id == userId)
                    {
                        foreach (var kvp in dictAttribute)
                        {
                            node.Attributes[kvp.Key].Value = kvp.Value;
                        }
                    }
                }

                //加密保存Xml文档  
                EncryptFile(xmlDoc, path);

                //将用户信息从xml文件中读出来用dt保存
                Global.DtUser = XmlToDataTable(path);

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }

        /// <summary>
        /// 向xml文件中添加节点
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool AddXmlNode(string path, DataRow dr)
        {
            bool f = false;

            try
            {
                XmlDocument xmlDoc = DecryptFile(path);

                XmlNode rootNode = xmlDoc.SelectSingleNode("Users");

                //创建子节点  
                XmlNode userNode = xmlDoc.CreateElement("user");
                //创建一个属性  
                XmlAttribute id = xmlDoc.CreateAttribute("id");
                id.Value = dr["id"].ToString();

                XmlAttribute name = xmlDoc.CreateAttribute("userName");
                name.Value = dr["userName"].ToString();

                XmlAttribute dept = xmlDoc.CreateAttribute("dept");
                dept.Value = dr["dept"].ToString();

                XmlAttribute password = xmlDoc.CreateAttribute("password");
                password.Value = dr["password"].ToString();

                XmlAttribute workNumber = xmlDoc.CreateAttribute("workNumber");
                workNumber.Value = dr["workNumber"].ToString();

                XmlAttribute permissions = xmlDoc.CreateAttribute("permissions");
                permissions.Value = dr["permissions"].ToString();

                userNode.Attributes.Append(id);
                userNode.Attributes.Append(name);
                userNode.Attributes.Append(dept);
                userNode.Attributes.Append(password);
                userNode.Attributes.Append(workNumber);
                userNode.Attributes.Append(permissions);

                rootNode.AppendChild(userNode);

                //加密保存Xml文档  
                EncryptFile(xmlDoc, path);

                //将用户信息从xml文件中读出来用dt保存
                Global.DtUser = XmlToDataTable(path);

                f = true;
            }
            catch (Exception ex)
            {
                f = false;
                Log.WriterExceptionLog(ex.ToString());
            }

            return f;
        }

        /// 将xml转为Datable
        /// </summary>
        public static DataTable XmlToDataTable(string xmlPath)
        {
            if (!string.IsNullOrEmpty(xmlPath))
            {
                try
                {
                    DataSet ds = new DataSet();

                    var xmlDoc = DecryptFile(xmlPath);

                    if (xmlDoc != null)
                    {
                        XmlNodeReader reader = new XmlNodeReader(xmlDoc);
                        ds.ReadXml(reader);
                    }

                    DataTable dt = ds.Tables[0];

                    return dt;
                }
                catch (Exception ex)
                {
                    Log.WriterExceptionLog(ex.ToString());
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// 加密XML文件
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="filePath"></param>
        public static void EncryptFile(XmlDocument xmlDoc, string filePath)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(xmlDoc.OuterXml);
                int num = bytes.Length - 1;
                for (int i = 0; i < num; i++)
                {
                    bytes[i] = (byte)(bytes[i] ^ bytes[i + 1]);
                }
                bytes[num] = (byte)(bytes[num] + 1);
                FileStream fileStream = File.Create(filePath);
                fileStream.Write(bytes, 0, num + 1);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite(string.Format("文件:{0}解析失败", filePath));
                Log.WriterExceptionLog(string.Format("文件:{0}加密失败", filePath));
            }
        }

        /// <summary>
        /// 解密XML文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static XmlDocument DecryptFile(string filePath)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                if (!File.Exists(filePath))
                {
                    Log.GetInstance().ErrorWrite(string.Format("文件:{0}不存在", filePath));
                    return null;
                }
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                byte[] array = new byte[fileStream.Length];
                int num = array.Length;
                fileStream.Read(array, 0, (int)fileStream.Length);
                array[num - 1] = (byte)(array[num - 1] - 1);
                for (int num2 = num - 2; num2 >= 0; num2--)
                {
                    array[num2] = (byte)(array[num2 + 1] ^ array[num2]);
                }

                string xml = Encoding.Default.GetString(array);
                xmlDocument.LoadXml(xml);
                fileStream.Close();

                return xmlDocument;
            }
            catch (Exception ex)
            {
                Log.GetInstance().ErrorWrite(string.Format("文件:{0}解析失败", filePath));
                Log.WriterExceptionLog(string.Format("文件:{0}解密失败", filePath));

                return null;
            }
        }
    }
}
