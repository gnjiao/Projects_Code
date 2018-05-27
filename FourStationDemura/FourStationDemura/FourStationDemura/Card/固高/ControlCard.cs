using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourStationDemura
{
    public class ControlCard
    {
        private short cardNumber = 0;

        private short axisCount = 4;

        /// <summary>
        /// 控制卡号
        /// </summary>
        public short CardNumber
        {
            get
            {
                return cardNumber;
            }

            set
            {
                cardNumber = value;
            }
        }

        /// <summary>
        /// 轴数量
        /// </summary>
        public short AxisCount
        {
            get
            {
                return axisCount;
            }

            set
            {
                axisCount = value;
            }
        }
    }
}
