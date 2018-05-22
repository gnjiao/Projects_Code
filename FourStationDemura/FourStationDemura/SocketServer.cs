using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace FourStationDemura
{
    public class SocketServer
    {
        #region 属性

        /// <summary>
        /// 服务器端ip
        /// </summary>
        public string ipString = "127.0.0.1";

        /// <summary>
        /// 服务器端口
        /// </summary>
        public int port = 37280;

        /// <summary>
        /// 服务端
        /// </summary>
        public Socket socketServer = null;

        /// <summary>
        /// 客户端(VCR)
        /// </summary>
        public Socket socketClient = null;

        /// <summary>
        /// 扫码后返回的编码
        /// </summary>
        private string mCode = "";

        /// <summary>
        /// 扫码后返回的编码
        /// </summary>
        public string Code
        {
            get { return mCode; }
            set { mCode = value; }
        }

        /// <summary>
        /// 标识当前是否启动了服务
        /// </summary>
        public bool isStarted = false;

        #endregion

        #region 构造函数

        public SocketServer(string ipString, int port)
        {
            this.ipString = ipString;
            this.port = port;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start()
        {
            try
            {
                IPAddress address = IPAddress.Parse(ipString);
                this.socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.socketServer.Bind(new IPEndPoint(address, port));
                this.socketServer.Listen(10000);
                this.isStarted = true;

                new Thread(listenClientConnect).Start(socketServer);
            }
            catch (Exception ex)
            {
                this.isStarted = false;
            }
        }

        /// <summary>
        /// 监听客户端的连接
        /// </summary>
        private void listenClientConnect(object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                Socket clientScoket = socket.Accept();

                new Thread(ReceiveData).Start(clientScoket);

                Thread.Sleep(1000);
                if (!this.isStarted) return;
            }
        }

        /// <summary>
        /// 通过socket发送数据data
        /// </summary>
        public void Send(string data)
        {
            //判断连接状态
            if (this.socketClient == null || this.socketClient.Poll(10, SelectMode.SelectRead) == true)
            {
                Log.GetInstance().ErrorWrite("跟VCR设备的通讯已断开");
                return;
            }

            if (this.socketClient != null && data != null && !data.Equals(""))
            {
                byte[] bytes = Encoding.Default.GetBytes(data);
                this.socketClient.Send(bytes);
            }
        }

        /// <summary>
        /// 接收通过socket发送过来的数据
        /// </summary>
        private void ReceiveData(object obj)
        {
            Socket socket = (Socket)obj;

            this.socketClient = socket;

            Log.GetInstance().NormalWrite("跟VCR设备的通讯已连接");

            while (true)
            {
                try
                {
                    byte[] bytes = null;
                    int len = this.socketClient.Available;
                    if (len > 0)
                    {
                        bytes = new byte[len];
                        int receiveNumber = this.socketClient.Receive(bytes);
                        this.mCode = Encoding.Default.GetString(bytes, 0, receiveNumber);
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
                Thread.Sleep(200);

                if (!this.isStarted) return;
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            this.isStarted = false;
        }

        #endregion
    }
}

