using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class IOC0640Card : IoCardBase
    {
        public IOC0640Card()
        {
        }

        /// <summary>
        /// 初始化IO卡
        /// </summary>
        /// <returns></returns>
        public override bool BoardInit(bool isShowLog)
        {
            bool f = false;

            int iRtn = IOC0640.ioc_board_init();
            if (iRtn == 0)
            {
                f = false;

                Log.GetInstance().ActionWrite(string.Format("初始化IO卡"), "没有读到IO卡", isShowLog);
            }
            else
            {
                f = true;

                Log.GetInstance().ActionWrite(string.Format("初始化IO卡"), "成功", isShowLog);
            }
            
            return f;
        }

        /// <summary>
        /// 关闭IO卡
        /// </summary>
        public override void BoardClose(bool isShowLog)
        {
            IOC0640.ioc_board_close();

            Log.GetInstance().ActionWrite(string.Format("关闭IO卡"), "成功", isShowLog);
        }

        /// <summary>
        /// 读取指定控制卡的某一位输入口的电平状态
        /// </summary>
        /// <param name="bitNo">指定输入口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public override int ReadInBit(ushort bitNo)
        {
            int iRtn = IOC0640.ioc_read_inbit(this.CardNo, bitNo);

            return iRtn;
        }

        /// <summary>
        /// 对指定控制卡的某一位输出口置位
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <param name="on_off">输出电平：0－表示输出低电平，1－表示输出高电平</param>
        /// <returns></returns>
        public override int WriteOutBit(ushort bitNo, ushort on_off)
        {
            int iRtn = (int)IOC0640.ioc_write_outbit(this.CardNo, bitNo, on_off);

            return iRtn;
        }

        /// <summary>
        /// 读取指定控制卡的某一位输出口的电平状态
        /// </summary>
        /// <param name="bitNo">指定输出口位号</param>
        /// <returns>0表示低电平；1表示高电平</returns>
        public override int ReadOutBit(ushort bitNo)
        {
            int iRtn = (int)IOC0640.ioc_read_outbit(this.CardNo, bitNo);

            return iRtn;
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输入口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <returns>portNo 为0时,bit0–bit31位值分别代表第1–32号输入端口值。
        ///portNo 为1时, bit0–bit14位值分别代表第33–47号输入端口值。
        ///</returns>
        public override int ReadInPort(ushort portNo)
        {
            int iRtn = (int)IOC0640.ioc_read_inport(this.CardNo, portNo);

            return iRtn;
        }

        /// <summary>
        /// 读取指定控制卡的全部通用输出口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <returns>portNo 为0时,bit0–bit31位值分别代表第1–32号输出端口值。
        ///portNo 为1时, bit0–bit15位值分别代表第33–48号输出端口值。
        ///</returns>
        public override int ReadOutPort(ushort portNo)
        {
            int iRtn = (int)IOC0640.ioc_read_outport(this.CardNo, portNo);

            return iRtn;
        }

        /// <summary>
        /// 指定控制卡的全部通用输出口的电平状态
        /// </summary>
        /// <param name="portNo">端口号,范围(0-1)</param>
        /// <param name="portValue">portNo 为0时,bit0–bit31位值分别代表第1–32号输出端口值。
        ///portNo 为1时, bit0–bit15位值分别代表第33–48号输出端口值</param>
        /// <returns></returns>
        public override int WriteOutPort(ushort portNo,uint portValue)
        {
            int iRtn = (int)IOC0640.ioc_write_outport(this.CardNo, portNo, portValue);

            return iRtn;
        }
    }
}
