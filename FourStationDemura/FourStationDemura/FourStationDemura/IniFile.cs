using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FourStationDemura
{
    /// <summary>
    /// ini文件读写类
    /// </summary>
    public static class IniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
                    string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
                    StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
            byte[] retVal, int size, string filePath);

        /// <summary>
        ///写INI文件
        /// </summary>
        /// <param name="section">字段名</param>
        /// <param name="key">键名</param>
        /// <param name="value">键对应的值</param>
        /// <param name="path">文件路径</param>
        public static void IniWriteValue(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// 读INI文件
        /// </summary>
        /// <param name="section">字段名</param>
        /// <param name="key">键名</param>
        /// <param name="path">文件路径</param>
        /// <returns>键对应的值</returns>
        public static string IniReadValue(string section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }

        /// <summary>
        /// 读取ini文件信息到字典
        /// </summary>
        /// <param name="section">字段名</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadSection(string section, string path, Dictionary<string, string> dict)
        {
            try
            {
                dict.Clear();
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    String line;
                    string[] str;

                    bool isStart = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isStart && line.Trim() == "[End]")
                        {
                            break;
                        }

                        if (line.Trim() == "")
                        {
                            continue;
                        }

                        if (isStart)
                        {
                            str = line.Split('=');

                            if (!dict.ContainsKey(str[0].ToString().Trim()))
                            {
                                dict.Add(str[0].ToString().Trim(), str[1].ToString().Trim());
                            }
                        }

                        if (line == "[" + section + "]")
                        {
                            isStart = true;
                        }
                    }

                    sr.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return dict;
        }
    }
}
