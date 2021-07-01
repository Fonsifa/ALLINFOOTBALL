using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using FeiMsgType;

namespace Fei
{
    /// <summary>
    /// 和客户端连接的通道类(内含Socket及ClientUser)
    /// </summary>
    class ClientConnection
    {
        #region 连接通道所属用户信息 - User
        ClientUser user = null;
        /// <summary>
        /// 连接通道所属用户信息
        /// </summary>
        public ClientUser User
        {
            get { return user; }
            set { user = value; }
        } 
        #endregion
        Thread threadClient = null;
        Socket socket = null;
        string strEndpoint;
        FrmMain frmMain = null;
        /// <summary>
        /// 是否退出-true退出/false运行
        /// </summary>
        bool doesClose = false;

        #region 构造函数
        public ClientConnection(FrmMain frmMain, Socket socket)
        {
            InitConnection(frmMain, socket);
        }

        public ClientConnection(FrmMain frmMain, Socket socket, ClientUser user)
        {
            InitConnection(frmMain, socket);
            this.user = user;
        } 
        #endregion

        #region 初始化连接 - InitConnection(FrmMain frmMain, Socket socket)
        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="frmMain">窗体</param>
        /// <param name="socket">连接套接字</param>
        public void InitConnection(FrmMain frmMain, Socket socket)
        {
            if (null == frmMain || null == socket) throw new UnPrepareConnectionException();//如果参数不足则抛出自定义异常
            this.frmMain = frmMain;
            this.socket = socket;
            this.strEndpoint = socket.RemoteEndPoint.ToString();
            threadClient = new Thread(WatchMsg);
            threadClient.IsBackground = true;
            threadClient.Start();
        } 
        #endregion

        #region -监听客户端消息 - WatchMsg()
        private void WatchMsg()
        {
            string strMsgRec = string.Empty;
            while (!doesClose)
            {
                try
                {
                    byte[] byteMsgRec = new byte[1024 * 1024 * 4];
                    int length = socket.Receive(byteMsgRec, byteMsgRec.Length, SocketFlags.None);
                    if (length > 0)
                    {
                        strMsgRec = Encoding.UTF8.GetString(byteMsgRec, 1, length - 1);//获取标志符后的消息字符串
                        if (byteMsgRec[0] == (byte)MsgType.UserMsg)//用户消息
                        {
                            MsgInfo msgInfo = new MsgInfo(strMsgRec);
                            if (msgInfo.UId != string.Empty)//有效消息
                            {
                                if (msgInfo.ToUid != string.Empty && msgInfo.IsPrivate)//如果接收人不为空而且是私聊信息
                                {
                                    frmMain.SendMsgUserToSingle(msgInfo.ToUid, msgInfo.ToTransString(), MsgType.UserMsg);
                                }
                                else//对所有人说
                                {
                                    frmMain.SendMsgUserToEveryoneButOne(msgInfo.ToTransString(), msgInfo.UId, MsgType.UserMsg);
                                }
                            }
                            ShowMsg(msgInfo.ToSayInServerTextBox());
                        }
                        else if (byteMsgRec[0] == (byte)MsgType.UserShake)//窗体抖动
                        {
                            string[] arrInfo = strMsgRec.Split(',');//fromUid,toUid
                            frmMain.SendMsgUserToSingle(arrInfo[1], arrInfo[0], MsgType.UserShake);
                            ShowMsg("用户【" + arrInfo[0] + "】向【" + arrInfo[1] + "】发送了窗体抖动！： )");
                        }
                        else if (byteMsgRec[0] == (byte)MsgType.UserFileSend)//用户请求发送文件
                        {
                            string[] arrFileInfo = strMsgRec.Split(',');//发送者Uid,接收者Uid,文件路径
                            frmMain.SendMsgUserToSingle(arrFileInfo[1], strMsgRec, MsgType.UserFileSend);
                            ShowMsg("用户【" + arrFileInfo[0] + "】向【" + arrFileInfo[1] + "】请求发送文件...");
                        }
                        else if (byteMsgRec[0] == (byte)MsgType.UserFileRec)//用户请求接收文件
                        {
                            string[] arrFileInfo = strMsgRec.Split(',');//fromUid,toUid,filePath
                            frmMain.SendMsgUserToSingle(arrFileInfo[0], strMsgRec, MsgType.UserFileRec);
                            ShowMsg("用户【" + arrFileInfo[1] + "】同意了从【" + arrFileInfo[0] + "】接收文件...");
                        }
                        else if (byteMsgRec[0] == (byte)MsgType.UserFileRefuse)//用户拒绝接收文件
                        {
                            string[] arrFileInfo = strMsgRec.Split(',');//fromUid,toUid,filePath
                            frmMain.SendMsgUserToSingle(arrFileInfo[0], strMsgRec, MsgType.UserFileRefuse);
                            ShowMsg("用户【" + arrFileInfo[1] + "】同意了从【" + arrFileInfo[0] + "】接收文件...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (socket != null)
                    {
                        frmMain.RemoveListItem(strEndpoint);
                        ShowErr("客户端【" + strEndpoint + "】退出聊天室!", ex);
                        ShowMsg("用户【" + strEndpoint + "】退出了！");
                        frmMain.SendUserQuitMsgToEveryone(this.strEndpoint);//将用户退出消息发给每一个在线用户
                    }
                    break;
                }
            }
        }
        #endregion

        #region 发送在线用户列表 - SendMsgOnlineList(string onlineList)
        /// <summary>
        /// 发送在线用户列表
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsgOnlineList(string onlineList)
        {
            SendMsgType(onlineList, MsgType.OnlineList);
        }
        #endregion

        #region 发送系统消息 - SendMsgSys(string msg)
        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="userID">用户ID </param>
        public void SendMsgSys(string msg)
        {
            SendMsgType(msg, MsgType.SysMsg);
        }
        #endregion

        #region 发送系统消息(用户退出) - SendMsgSys()
        /// <summary>
        /// 发送系统消息(用户退出) 
        /// </summary>
        public void SendSysMsgUserQuit(string uId)
        {
            SendMsgType(uId, MsgType.SysMsgUserQuit);
        }
        #endregion

        #region 发送系统消息(服务器退出) - SendSysMsgQuit()
        /// <summary>
        /// 发送系统消息(服务器退出) 
        /// </summary>
        public void SendSysMsgQuit()
        {
            SendMsgType(this.strEndpoint, MsgType.SysQuit);
        }
        #endregion

        #region 发送系统消息(在线负载限制) - SendSysMsgOnlineLimit()
        /// <summary>
        /// 发送系统消息(在线负载限制) 
        /// </summary>
        public void SendSysMsgOnlineLimit()
        {
            SendMsgType("聊天室负载已达极限，请过段时间再试～ : )！", MsgType.SysMsgUserQuit);
        }
        #endregion

        #region 发送不同类型的消息 - SendMsgType(string msg,MsgType type)
        /// <summary>
        /// 发送不同类型的消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="type">类型</param>
        public void SendMsgType(string msg,MsgType type)
        {
            try
            {
                byte[] msgSendByte = Encoding.UTF8.GetBytes(msg);
                byte[] finalByte = new byte[msgSendByte.Length + 1];
                finalByte[0] = (byte)type;
                Buffer.BlockCopy(msgSendByte, 0, finalByte, 1, msgSendByte.Length);
                socket.Send(finalByte);
            }
            catch (Exception ex)
            {
                ShowErr("SendMsg(string msg)", ex);
            }
        } 
        #endregion

        #region 发送文件 - SendFile(string fileName)
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        public void SendFile(string fileName)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open);
                byte[] byteFile = new byte[1024 * 1024 * 5];
                int length = fs.Read(byteFile, 0, byteFile.Length);
                if (length > 0)
                {
                    byte[] byteFinalFile = new byte[length + 1];
                    byteFinalFile[0] = (byte)MsgType.UserFile;
                    Buffer.BlockCopy(byteFile, 0, byteFinalFile, 1, length);
                    socket.Send(byteFinalFile);
                }
            }
            catch (Exception ex)
            {
                ShowErr("SendFile(string fileName)", ex);
            }
            finally
            {
                fs.Close();
            }
        } 
        #endregion

        #region 发送抖动 - SendShake()
        /// <summary>
        /// 发送抖动
        /// </summary>
        public void SendShake()
        {
            try
            {
                byte[] msgSendByte = Encoding.UTF8.GetBytes(this.strEndpoint);
                byte[] finalByte = new byte[msgSendByte.Length + 1];
                finalByte[0] = (int)MsgType.UserShake;
                Buffer.BlockCopy(msgSendByte, 0, finalByte, 1, msgSendByte.Length);
                socket.Send(finalByte);
            }
            catch (Exception ex)
            {
                ShowErr("SendShake()", ex);
            }
        }
        #endregion

        #region 关闭与客户端连接 - Close()
        /// <summary>
        /// 关闭与客户端连接
        /// </summary>
        public void Close()
        {
            SendMsgType("对不起，服务端退出～～", MsgType.SysMsg);
            doesClose = true;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        } 
        #endregion

        public void AbortThread()
        {
            threadClient.Abort();
        }

        #region -在窗体面板上显示消息
        private void ShowErr(string msg, Exception ex)
        {
            frmMain.ShowErr(msg, ex);
        }

        private void ShowMsg(string msg)
        {
            frmMain.ShowMsg(msg);
        }
        private void ShowLog(string msg)
        {
            frmMain.ShowLog(msg);
        } 
        #endregion
    }
}
