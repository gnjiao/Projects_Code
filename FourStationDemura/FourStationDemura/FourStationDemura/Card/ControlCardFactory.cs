using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    /// <summary>
    /// 运动控制卡工厂
    /// </summary>
    public class ControlCardFactory
    {
         private static ControlCardBase cardBase;
         private static object objLock = new object();
         private static ControlCardType cardType = ControlCardType.DMC2C80;

        /// <summary>
        /// 创建一个运动控制卡
        /// </summary>
        /// <param name="axisType">控制卡类型</param>
        private static ControlCardBase CreateAxis(ControlCardType cardType)
        {
            switch (cardType)
            {
                case ControlCardType.DMC2C80:
                    return new DMC2C80Card();
                    break;
                default:
                    throw new Exception("没有此类型!!!");
                    break;
            }
        }
        /// <summary>
        /// 获取一个轴卡实例
        /// </summary>
        /// <returns></returns>
        public static ControlCardBase GetIntance()
        {
            return GetIntance(cardType);
        }

        static public ControlCardBase GetIntance(ControlCardType cardType)
        {
            if (cardBase == null)
            {
                lock (objLock)
                {
                    if (cardBase == null)
                    {
                        cardBase = CreateAxis(cardType);
                    }
                }
            }
            return cardBase;
        }
    }

    /// <summary>
    /// 控制卡类型
    /// </summary>
    public enum ControlCardType
    {
        DMC2C80
    }

    /// <summary>
    /// 轴停止类型
    /// </summary>
    public enum AxisStopType
    {
        //指定轴减速停止
        DecelStop,
        //指定轴急停
        ImdStop,
        //同步停止所有轴
        SimultaneousStop,
        //紧急停止所有轴
        EmgStop
    }

    /// <summary>
    /// 曲线运动模式类型
    /// </summary>
    public enum ProFileType
    {
        S = 0,
        T
    }

    /// <summary>
    /// 版本号类型
    /// </summary>
    public enum VersionType
    {
        //软件版本号
        LibVersion = 0,
        //硬件版本号
        CardVersion,
        //固件版本号
        FirmVersion
    }
}
