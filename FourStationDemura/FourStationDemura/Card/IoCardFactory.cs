using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class IoCardFactory
    {
        private static IoCardBase ioCardBase;
        private static object objLock = new object();
        private static IoCardType ioCardType = IoCardType.IOC0640;

        /// <summary>
        /// 创建一个IO卡
        /// </summary>
        /// <param name="ioCardType">IO卡类型</param>
        private static IoCardBase CreateAxis(IoCardType ioCardType)
        {
            switch (ioCardType)
            {
                case IoCardType.IOC0640:
                    return new IOC0640Card();
                    break;
                default:
                    throw new Exception("没有此类型!!!");
                    break;
            }
        }
        /// <summary>
        /// 获取一个IO卡实例
        /// </summary>
        /// <returns></returns>
        public static IoCardBase GetIntance()
        {
            return GetIntance(ioCardType);
        }

        static public IoCardBase GetIntance(IoCardType ioCardType)
        {
            if (ioCardBase == null)
            {
                lock (objLock)
                {
                    if (ioCardBase == null)
                    {
                        ioCardBase = CreateAxis(ioCardType);
                    }
                }
            }
            return ioCardBase;
        }
    }

    /// <summary>
    /// 控制卡类型
    /// </summary>
    public enum IoCardType
    {
        IOC0640
    }

}
