using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class IoCardBase
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public ushort CardNo { set; get; }

        /// <summary>
        /// 初始化IO卡
        /// </summary>
        /// <returns></returns>
        public virtual bool BoardInit(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 关闭IO卡
        /// </summary>
        public virtual void BoardClose(bool isShowLog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的某一位输入口的电平状态
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public virtual int ReadInBit(ushort bitNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 对指定控制卡的某一位输出口置位
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <param name="on_off">输出电平：0－表示输出低电平，1－表示输出高电平</param>
        /// <returns></returns>
        public virtual int WriteOutBit(ushort bitNo, ushort on_off)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的某一位输出口的电平状态
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public virtual int ReadOutBit(ushort bitNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输入口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <returns>portNo 为0时,bit0–bit31位值分别代表第1–32号输入端口值。
        ///portNo 为1时, bit0–bit14位值分别代表第33–47号输入端口值。
        ///</returns>
        public virtual int ReadInPort(ushort portNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输出口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <returns>portNo 为0时,bit0–bit31位值分别代表第1–32号输出端口值。
        ///portNo 为1时, bit0–bit15位值分别代表第33–48号输出端口值。
        ///</returns>
        public virtual int ReadOutPort(ushort portNo)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 指定控制卡的全部通用输出口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <param name="portValue">portNo 为0时,bit0–bit31位值分别代表第1–32号输出端口值。
        ///portNo 为1时, bit0–bit15位值分别代表第33–48号输出端口值</param>
        /// <returns></returns>
        public virtual int WriteOutPort(ushort portNo, uint portValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
