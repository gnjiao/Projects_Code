using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class GtsBoard
    {
        /// <summary>
        /// 复位运动控制器
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        public static short GT_Reset(ControlCard cardInfo)
        {
            short sRtn = Gts.GT_Reset(cardInfo.CardNumber);

            return sRtn;
        }

        /// <summary>
        /// 清除驱动器报警标志
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">起始轴号</param>
        /// <param name="count">读取的轴数，默认为1</param>
        public static short GT_ClrSts(ControlCard cardInfo, short axis,short count)
        {
            short sRtn = Gts.GT_ClrSts(cardInfo.CardNumber, axis, count);

            return sRtn;
        }

        /// <summary>
        /// 初始化运动控制器 
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="pFile">配置文件路径</param>
        public static short GT_LoadConfig(ControlCard cardInfo, string pFile)
        {
            short sRtn = Gts.GT_LoadConfig(cardInfo.CardNumber, pFile);

            if (sRtn != 0)
            {
                return sRtn;
            }

            sRtn = GT_ClrSts(cardInfo, 1, cardInfo.AxisCount);

            return sRtn;
        }

        /// <summary>
        /// 打开运动控制器
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="channel">打开运动控制器的方式,0=正常打开，1=调试模式</param>
        /// <param name="param">channel=1时生效</param>
        /// <returns></returns>
        public static short GT_Open(ControlCard cardInfo,short channel,short param)
        {
            short sRtn = Gts.GT_Open(cardInfo.CardNumber, channel, param);

            return sRtn;
        }

        /// <summary>
        /// 关闭运动控制器
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <returns></returns>
        public static short GT_Close(ControlCard cardInfo)
        {
            short sRtn = Gts.GT_Close(cardInfo.CardNumber);

            return sRtn;
        }

        /// <summary>
        /// 打开驱动器使能
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static short GT_AxisOn(ControlCard cardInfo,short axis)
        {
            short sRtn = Gts.GT_AxisOn(cardInfo.CardNumber, axis);

            return sRtn;
        }

        /// <summary>
        /// 关闭驱动器使能
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static short GT_AxisOff(ControlCard cardInfo, short axis)
        { 
            short sRtn = Gts.GT_AxisOff(cardInfo.CardNumber, axis);

            return sRtn;
        }

        /// <summary>
        /// 清零规划位置和实际位置，并进行零漂补
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">需要位置清零的起始轴号</param>
        /// <param name="count">需要位置清零的轴数</param>
        /// <returns></returns>
        public static short GT_ZeroPos(ControlCard cardInfo, short axis, short count)
        {
            short sRtn = Gts.GT_ZeroPos(cardInfo.CardNumber, axis, count);

            return sRtn;
        }

        /// <summary>
        /// 设置指定轴为点位运动模式
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public static short GT_PrfTrap(ControlCard cardInfo, short axis)
        {
            short sRtn = Gts.GT_PrfTrap(cardInfo.CardNumber, axis);

            //当前轴再规划运动，先停止GT_Stop 
            if (sRtn == 1)
            {
                sRtn = GT_Stop(cardInfo, 1 << (axis - 1), 0);

                if (sRtn == 0)
                {
                    GT_PrfTrap(cardInfo, axis);
                }
            }

            return sRtn;
        }

        /// <summary>
        /// 停止运动
        /// </summary>
        /// <param name="cardInfo">控制卡实体类</param>
        /// <param name="axis">轴号</param>
        /// <param name="option">急停方式，0=平滑，1=急停</param>
        /// <returns></returns>
        public static short GT_Stop(ControlCard cardInfo,int axis, int option)
        {
            int mask = 1 << (axis - 1);
            short sRtn = Gts.GT_Stop(cardInfo.CardNumber, mask, option);

            return sRtn;
        }
    }
}
