using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using FeiMsgType;

namespace Main
{
    public partial class SimpleChatV1Client : Form
    {
        public int User_Id;
        public SimpleChatV1Client(int User_Id)
        {

            InitializeComponent();
            this.User_Id = User_Id;
            dgShowMsg = new DGShowMsg(DoShowMsg);
            InitSocketAndConnect();
        }

        private void SimpleChatV1Client_Load(object sender, EventArgs e)
        {
            LoadMoodCbo();
            cboMood.SelectedIndex = 0;
            //cboToUser.SelectedIndex = 0;
            ShowMsg("\n");
            ShowMsgPrivate("\n");

            Panel.CheckForIllegalCrossThreadCalls = false;
        }

        Socket socketClient;
        Thread threadClient;
        IPAddress address;
        IPEndPoint endP;
        bool isClose = false;//是否关闭
        bool isForbidTalk = false;//是否被禁言
        private void StartThread()
        {
            threadClient = new Thread(WatchMsg);
            threadClient.SetApartmentState(ApartmentState.STA);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        #region 初始化对象并连接服务端
        private void InitSocketAndConnect()
        {
            try
            {
                string txtIP = "10.132.2.72";
                string txtPort = "8750";
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                address = IPAddress.Parse(txtIP.Trim());
                endP = new IPEndPoint(address, int.Parse(txtPort.Trim()));
                socketClient.Connect(endP);
                lblMyUID.Text = this.User_Id.ToString();
                StartThread();
                ShowMsg("连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitSocketAndConnect() Wrong");
            }
        }
        #endregion

        private void DoShowMsg(string msg, int type)
        {
            if (type == 1)
                txtMsgPublic.AppendText(msg + "\r\n");

        }

        private void ShowErr(string msg, Exception ex)
        {
            ShowMsg("\r------------------" + msg + "-----------------\r\n" + ex.Message + "\r");
        }
         private void ShowSysMsg(string msg,int type)
        {
            ShowMsgPrivate(msg);
           
        } 
        private void ShowSysMsg(string msg)
        {
            ShowSysMsg(msg, 0);
        }
        private void WatchMsg()
        {
            while (!isClose)
            {
                byte[] msgByte = new byte[1024 * 1024 * 2];
                int length = 0;
                try
                {
                    length = socketClient.Receive(msgByte, msgByte.Length, SocketFlags.None);
                    if (length > 0)
                    {
                        //MessageBox.Show("OK");
                        if (msgByte[0] == (byte)MsgType.UserMsg)//接收用户消息
                        {
                            string strMsgRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            MsgInfo msgInfo = new MsgInfo(strMsgRec);
                            if (true)//有效用户聊天消息
                            {
                                if (msgInfo.IsPrivate)
                                    ShowMsgPrivate(msgInfo.ToSayInClient(lblMyUID.Text));
                                else
                                    ShowMsg(msgInfo.ToSayInClient(lblMyUID.Text));
                            }
                        }
                        else if (msgByte[0] == (byte)MsgType.UserFile)//接收用户文件
                        {
                            ShowMsgPrivate("原来的接收用户文件代码");
                            #region MyRegion
                            SaveFileDialog sfd = new SaveFileDialog();
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                string savePath = sfd.FileName;
                                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                                {
                                    fs.Write(msgByte, 1, length - 1);
                                    ShowMsg("文件保存成功：" + savePath);
                                }
                            }
                            #endregion
                        }
                        else if (msgByte[0] == (byte)MsgType.SysMsg)//接收系统消息
                        {
                            ShowSysMsg(Encoding.UTF8.GetString(msgByte, 1, length - 1));
                        }
                        else if (msgByte[0] == (byte)MsgType.OnlineList)//接收在线列表
                        {
                            //ListAllOnlineUsers(Encoding.UTF8.GetString(msgByte, 1, length - 1));
                        }
                        else if (msgByte[0] == (byte)MsgType.SysMsgUserQuit)//接收系统消息(有用户退出)
                        {
                            ShowMsg("用户【" + Encoding.UTF8.GetString(msgByte, 1, length - 1) + "】退出了！");
                        }
                        else if (msgByte[0] == (byte)MsgType.SysQuit)//接收系统消息(服务端退出)
                        {
                            MessageBox.Show("服务端退出了！客户端自动关闭！");
                            ExitClient();
                        }
                        else if (msgByte[0] == (byte)MsgType.UserShake)//窗体抖动
                        {
                            ShowMsg("用户【" + Encoding.UTF8.GetString(msgByte, 1, length - 1) + "】向您发送了窗体抖动！： )");
                            ShakeWindow();
                        }
                        else if (msgByte[0] == (byte)MsgType.UserFileSend)//用户请求发送文件--接收端此时开始开启【文件接收Socket】监听文件传送端口
                        {
                            string strMsgRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrFileInfo = strMsgRec.Split(',');//格式：发送者Uid,接收者Uid,文件路径
                            if (MessageBox.Show("用户【" + arrFileInfo[0] + "】向您发送文件:" + arrFileInfo[2] + ",您是否接收？", "文件接收请求", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                socketClient.Send(MsgInfo.ToByteArrTypeMsg(strMsgRec, MsgType.UserFileRec));
                                BeginReciFile();//此时开始开启【文件接收Socket】监听文件传送端口
                                ShowMsgPrivate("正等待发送端发送文件......");
                            }
                            else
                            {
                                socketClient.Send(MsgInfo.ToByteArrTypeMsg(strMsgRec, MsgType.UserFileRefuse));
                                ShowMsgPrivate("您已经拒绝发送端发送文件......");
                            }
                        }
                        else if (msgByte[0] == (byte)MsgType.UserFileRec)//用户请求接收文件--发送端此时开始传送文件
                        {
                            string strMsgRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            ShowMsgPrivate("发送端开始传送文件...");
                            string[] arrFileInfo = strMsgRec.Split(',');//发送者Uid,接收者Uid,文件路径
                            #region 传送文件
                            try
                            {
                                using (FileStream fs = new FileStream(arrFileInfo[2], FileMode.Open))
                                {
                                    byte[] arrFileByte = new byte[1024 * 1024 * 4];
                                    int lengthFile = fs.Read(arrFileByte, 0, arrFileByte.Length);//读取文件到数组中
                                    if (lengthFile > 0)
                                    {
                                        byte[] byteFinalFile = new byte[lengthFile + 1];
                                        byteFinalFile[0] = (byte)MsgType.UserFile;//设置标识位：用户文件
                                        Buffer.BlockCopy(arrFileByte, 0, byteFinalFile, 1, lengthFile);
                                        //创建临时套接字(用来向接收端发送文件)
                                        Socket socketTemp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                        socketTemp.Connect(new IPEndPoint(IPAddress.Parse(arrFileInfo[0].Split(':')[0]), fileRecPort));
                                        socketTemp.Send(byteFinalFile);
                                        //socketTemp.Close();
                                        ShowMsgPrivate("发送完毕！(" + lengthFile + "字节)");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowErr("发送文件", ex);
                            }
                            #endregion
                        }
                        else if (msgByte[0] == (byte)MsgType.UserFileRefuse)//用户拒绝接收文件
                        {
                            string strMsgRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrFileInfo = strMsgRec.Split(',');//格式：fromUid,toUid,filePath
                            ShowMsgPrivate("用户【" + arrFileInfo[1] + "】拒绝接收文件......");
                        }
                        else if (msgByte[0] == (byte)MsgType.SysBeKickOut)//用户被踢出聊天室
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            MessageBox.Show("你因为【" + strReasonRec + "】被管理员踢出聊天室！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ExitClient();
                        }
                        else if (msgByte[0] == (byte)MsgType.SysKickedOne)//有用户被踢出了
                        {
                            string strMsgRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrMsg = strMsgRec.Split('|');//格式：reason|uid
                           // RemoveListItem(arrMsg[1]);
                            ShowSysMsg("用户【" + arrMsg[1] + "】因【" + arrMsg[0] + "】被管理员踢出聊天室了......", 1);
                        }
                        else if (msgByte[0] == (byte)MsgType.SysBeForbid)//禁言
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            ShowSysMsg("你因为【" + strReasonRec + "】被管理员禁止发言！");
                            isForbidTalk = true;
                        }
                        else if (msgByte[0] == (byte)MsgType.SysForbidOne)//用户被禁言
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrMsg = strReasonRec.Split('|');//格式：reason|uid
                            ShowSysMsg("用户【" + arrMsg[1] + "】因【" + arrMsg[0] + "】被管理员禁止发言！", 1);
                        }
                        else if (msgByte[0] == (byte)MsgType.SysNoForbid)//解除禁言
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            isForbidTalk = false;
                            ShowSysMsg("你因为【" + strReasonRec + "】被管理员解除禁言！");
                        }
                        else if (msgByte[0] == (byte)MsgType.SysNoForbidOne)//用户被解除禁言
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrMsg = strReasonRec.Split('|');//格式：reason|uid
                            ShowSysMsg("用户【" + arrMsg[1] + "】因【" + arrMsg[0] + "】被管理员解除禁言！", 1);
                        }
                        else if (msgByte[0] == (byte)MsgType.SysBeWarning)//被警告
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            ShowSysMsg("你因为【" + strReasonRec + "】被管理员警告了！");
                        }
                        else if (msgByte[0] == (byte)MsgType.SysWarningOne)//用户被警告
                        {
                            string strReasonRec = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                            string[] arrMsg = strReasonRec.Split('|');//格式：reason|uid
                            ShowSysMsg("用户【" + arrMsg[1] + "】因【" + arrMsg[0] + "】被管理员警告！", 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowErr("WatchMsg()", ex);
                    break;
                }
            }
        }

        #region 控制窗体抖动方法
        /// <summary>
        /// 控制窗体抖动方法
        /// </summary>
        public void ShakeWindow()
        {
            Random ran = new Random();
            System.Drawing.Point point = this.Location;
            for (int i = 0; i < 30; i++)
            {
                this.Location = new System.Drawing.Point(point.X + ran.Next(5), point.Y + ran.Next(5));
                System.Threading.Thread.Sleep(15);
                this.Location = point;
                System.Threading.Thread.Sleep(15);
            }
        }
        #endregion

        #region 开始连接服务器
        private void btnWatch_Click(object sender, EventArgs e)
        {
            InitSocketAndConnect();
        }
        #endregion

        #region 显示消息相关
        delegate void DGShowMsg(string msg, int type);
        DGShowMsg dgShowMsg;

        /// <summary>
        /// 显示信息在公聊面板
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            try
            {
                if (dgShowMsg != null)
                {
                    this.Invoke(dgShowMsg, msg, 1);
                }
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// 显示系统消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="type">消息类型(0-系统警告,1-系统提示)</param>

        #endregion

        #region 显示信息在私聊面板
        /// <summary>
        /// 显示信息在私聊面板
        /// </summary>
        /// <param name="msg">消息</param>
        private void ShowMsgPrivate(string msg)
        {
            try
            {
                if (dgShowMsg != null)
                {
                    this.Invoke(dgShowMsg, msg, 2);
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion




        #region 发送消息
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!CheckBeforeSend())
            {
                MessageBox.Show("您已经被禁言");
                return;
            }
            if (socketClient != null)
            {
                try
                {
                    sql s = new sql();
                    s.connectToDatabase();
                    s.createTable();
                    s.createTable2();
                    string nickName = s.look(User_Id.ToString());
                    MsgInfo msgInfo = new MsgInfo();
                    msgInfo.UId = nickName;
                    msgInfo.Mood = cboMood.SelectedItem.ToString();
                    msgInfo.ToUid = "所有人";
                    msgInfo.IsPrivate = chkPrivateTalk.Checked;
                    msgInfo.Content = txtInput.Text.Trim();
                    socketClient.Send(MsgInfo.ToByteArrTypeMsg(msgInfo.ToTransString(), MsgType.UserMsg));
                    if (msgInfo.IsPrivate)
                        ShowMsgPrivate(msgInfo.ToSayInClient(nickName));//显示在私聊窗口中
                    else {; }
                        //ShowMsg(msgInfo.ToSayInClient(nickName));//显示在公聊窗口中
                }
                catch (SocketException ex)
                {
                    ShowErr("发送消息时", ex);
                }
            }
            else
            {
                ShowMsg("系统提示：您尚未连接服务器～～～！");
            }
        }
        #endregion

        #region 发送屏幕抖动
        /// <summary>
        /// 发送屏幕抖动
        /// </summary>
        private void btnShake_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend())
                socketClient.Send(MsgInfo.ToByteArrTypeMsg(lblMyUID.Text + "," , MsgType.UserShake));
        }
        #endregion

        #region 在发送消息前检查是否选中聊天对象 - CheckBeforeSend()
        /// <summary>
        /// 在发送消息前检查是否选中聊天对象
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSend()
        {
            if (chkPrivateTalk.Checked && "ok" == string.Empty) { ShowMsgPrivate("私聊必须选择聊天对象！"); return false; }
            else if (isForbidTalk) { ShowMsgPrivate("您已经被禁止发言了！"); return false; }
            else return true;
        }
        #endregion

        #region 退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗?", "系统提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ExitClient();
            }
        }
        #endregion

        #region 关闭客户端
        /// <summary>
        /// 关闭客户端
        /// </summary>
        private void ExitClient()
        {
            if (socketClient != null)
            {
                socketClient.Close();
                isClose = false;
            }
            Application.Exit();
        }
        #endregion

       

        #region 加载语气下拉框 - LoadMoodCbo()
        /// <summary>
        /// 加载语气下拉框
        /// </summary>
        private void LoadMoodCbo()
        {
            string moods = System.Configuration.ConfigurationManager.AppSettings["moods"];
            string[] arrMoods = moods.Split('|');
            foreach (string mood in arrMoods)
            {
                cboMood.Items.Add(mood);
            }
        }
        #endregion


        #region 选择文件路径
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "发送端-请选择要发送的文件：";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }
        #endregion

        #region 发送文件 - btnSendFile_Click
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend() &&"ok"!= string.Empty)
            {
                if (!string.IsNullOrEmpty(txtFilePath.Text))
                    socketClient.Send(MsgInfo.ToByteArrTypeMsg(lblMyUID.Text + "," + "," + txtFilePath.Text, MsgType.UserFileSend));
                else
                    ShowMsgPrivate("请选择要发送的文件！");
            }
            else
                ShowMsgPrivate("请选择要发送文件的用户！");
        }
        #endregion

        #region *********收发文件*********
        /// <summary>
        /// 用来监听用户传送文件
        /// </summary>
        Socket socketFileRecWatcher;
        /// <summary>
        /// 用来监听用户传送文件
        /// </summary>
        Thread threadFileRecive;
        string fileRecIP = string.Empty;
        /// <summary>
        /// 用来传递文件的端口
        /// </summary>
        int fileRecPort = 46777;

        /// <summary>
        /// 开启监听文件传送端口
        /// </summary>
        private void BeginReciFile()
        {
            try
            {
                fileRecIP = socketClient.LocalEndPoint.ToString().Split(':')[0];
                if (null == socketFileRecWatcher)//如果是第一次接收文件则实例化监听套接字
                {
                    socketFileRecWatcher = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketFileRecWatcher.Bind(new IPEndPoint(IPAddress.Parse(fileRecIP), fileRecPort));
                    socketFileRecWatcher.Listen(1);
                }
                threadFileRecive = new Thread(WaitFile);
                threadFileRecive.IsBackground = true;
                threadFileRecive.Start();
            }
            catch (Exception ex)
            {
                ShowErr("开启监听文件传送端口", ex);
            }
        }
        /// <summary>
        /// 等待和接收文件
        /// </summary>
        private void WaitFile()
        {
            try
            {
                Socket socketFileRecive = socketFileRecWatcher.Accept();
                byte[] arrByteFile = new byte[1024 * 1024 * 4];
                int length = socketFileRecive.Receive(arrByteFile, arrByteFile.Length, SocketFlags.None);
                if (length > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    //文本文件(*.txt)|*.txt|所有文件(*.*)|*.*
                    sfd.Filter = "JPEG图片(*.jpg)|*.jpeg;*.jpg|位图文件(*.bmp)|*.bmp|所有文件(*.*)|*.*";
                    sfd.DefaultExt = "txt";
                    sfd.Title = "接收端-请选择保存路径：";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            fs.Write(arrByteFile, 1, length - 1);
                            ShowMsgPrivate("文件:" + length + "字节,成功保存到：" + sfd.FileName);
                        }
                    }
                    else
                    {
                        ShowMsgPrivate("您已经取消保存对方发来的文件~ : )");
                    }
                }
                //socketFileRecive.Shutdown(SocketShutdown.Both);
                //socketFileRecive.sh
                //socketFileRecive.Close();
                //socketFileRecive = null;
            }
            catch (Exception ex)
            {
                ShowErr("文件接收保存", ex);
            }
        }
        #endregion

        #region 清空文本框
        private void btnClearPublic_Click(object sender, EventArgs e)
        {
            txtMsgPublic.Text = "";
        }


        #endregion

        private void txtMsgPublic_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
