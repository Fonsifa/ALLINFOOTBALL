using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

using FeiMsgType;

namespace Fei
{

    delegate void DGShowMsg(string msg,ShowType type);
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            dgShowMsg = new DGShowMsg(DoShowMsg);
            ListView.CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cboMaxCount.SelectedIndex = 0;
        }

        #region 显示消息相关
        public void ShowErr(string msg, Exception ex)
        {
            ShowLog("----------------------Err begin------------------------");
            ShowLog(msg + ":" + ex.Message);
            ShowLog("----------------------Err end  ------------------------");
        }
        public void ShowConsoleMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        //-------------ShowMsg begin----------------
        public void ShowMsg(string msg)
        {
            if (dgShowMsg != null)
                this.Invoke(dgShowMsg, msg, ShowType.UserMsg);
        }
        DGShowMsg dgShowMsg = null;
        void DoShowMsg(string msg, ShowType type)
        {
            if (type == ShowType.UserMsg)
                txtShow.AppendText(msg + "\r\n");
            else if (type == ShowType.Log)
                txtLog.AppendText(msg + "\r\n");
        }
        //-------------ShowMsg end------------------
        //-------------ShowLog begin----------------
        public void ShowLog(string msg)
        {
            if (dgShowMsg != null)
                this.Invoke(dgShowMsg, msg, ShowType.Log);
        }
        //-------------ShowLog end------------------ 
        #endregion

        Thread threadWatchPort = null;
        Socket sokWatchPort = null;
        Dictionary<string, ClientConnection> dictConnections = new Dictionary<string, ClientConnection>();
        IPAddress address = null;
        IPEndPoint endpoint = null;
        /// <summary>
        /// 在线人数
        /// </summary>
        int countOnline = 0;
        /// <summary>
        /// 最大负荷数
        /// </summary>
        int countLimite = 0;

        #region -启动服务
        private void btnBegin_Click(object sender, EventArgs e)
        {
            WatchConnection();
        } 
        #endregion

        #region -开始监听客户连接
        /// <summary>
        /// 开始监听客户连接
        /// </summary>
        private void WatchConnection()
        {
            try
            {
                address = IPAddress.Parse(txtSerIP.Text.Trim());
                endpoint = new IPEndPoint(address, int.Parse(txtSerPort.Text.Trim()));
                sokWatchPort = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sokWatchPort.Bind(endpoint);
                sokWatchPort.Listen(10);
                threadWatchPort = new Thread(WatchPort);
                threadWatchPort.Name = "threadWatchPort";
                threadWatchPort.IsBackground = true;
                threadWatchPort.Start();
                ShowLog("启动完毕，等待客户端连接......");
                txtStatu.Text = "已启动";
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        } 
        #endregion

        #region -监听端口
        private void WatchPort()
        {
            while (true)
            {
                try
                {
                    Socket cSok = sokWatchPort.Accept();
                    ClientConnection conn = new ClientConnection(this, cSok);
                    if (countOnline == countLimite)//如果超过负载，则拒绝
                    {
                        conn.SendSysMsgOnlineLimit();
                        conn.Close();
                        conn = null;
                    }
                    else
                    {
                        string strClientEndpoint = cSok.RemoteEndPoint.ToString();//获得客户端IP:PORT
                        if (!dictConnections.ContainsKey(strClientEndpoint))//如果已添加过
                        {
                            conn.User = new FeiMsgType.ClientUser();
                            conn.User.Name = strClientEndpoint;
                            conn.User.LoginTime = DateTime.Now;
                            ShowLog("客户端【" + strClientEndpoint + "】连接成功...");//添加服务端日志
                            SendMsgSysToEveryone("欢迎【" + strClientEndpoint + "】进入聊天室！: )");
                            dictConnections.Add(strClientEndpoint, conn);//将新连接添加到在线用户列表字典中
                            AddClientToList(cSok.RemoteEndPoint.ToString());//添加到列表控件中
                            AddOnlineCount();//追加在线人数
                            SendUserListToEveryone();//发送给所有在线用户
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowErr("WatchPort()", ex);
                    break;
                }
            }
        } 
        #endregion

        #region 将在线列表发给每一个在线用户 - SendUserListToEveryone()
        /// <summary>
        /// 将在线列表发给每一个在线用户
        /// </summary>
        public void SendUserListToEveryone()
        {
            string strUserList = GetOnlineUserList();
            if (strUserList.Length < 3) return;//如果长度小于3则终止方法
            foreach (ClientConnection conn in dictConnections.Values)
            {
                conn.SendMsgOnlineList(strUserList);
            }
        } 
        #endregion

        #region 将用户退出消息发给每一个在线用户 - SendUserQuitMsgToEveryone()
        /// <summary>
        /// 将用户退出消息发给每一个在线用户
        /// </summary>
        public void SendUserQuitMsgToEveryone(string uId)
        {
            foreach (ClientConnection conn in dictConnections.Values)
            {
                conn.SendSysMsgUserQuit(uId);
            }
        }
        #endregion

        #region 将服务器退出消息发给每一个在线用户 - SendSysQuitMsgToEveryone()
        /// <summary>
        /// 将服务器退出消息发给每一个在线用户
        /// </summary>
        public void SendSysQuitMsgToEveryone()
        {
            foreach (ClientConnection conn in dictConnections.Values)
            {
                conn.SendSysMsgQuit();
            }
        }
        #endregion

        #region 将系统消息发给每一个在线用户 - SendMsgToEveryone(string msg)
        /// <summary>
        /// 将系统消息发给每一个在线用户
        /// </summary>
        public void SendMsgSysToEveryone(string msg)
        {
            if (msg.Length < 1) return;//如果长度小于3则终止方法
            foreach (ClientConnection conn in dictConnections.Values)
            {
                conn.SendMsgSys(msg);
            }
        }
        #endregion

        #region 将用户消息发给每一个在线用户 - SendMsgToEveryone(string msg)
        /// <summary>
        /// 将用户消息发给每一个在线用户
        /// </summary>
        public void SendMsgUserToEveryone(string msg, MsgType type)
        {
            if (msg.Length < 1) return;//如果长度小于3则终止方法
            foreach (ClientConnection conn in dictConnections.Values)
            {
                conn.SendMsgType(msg, type);
            }
        }
        #endregion

        #region 将用户消息发给每一个在线用户 - SendMsgUserToEveryoneButOne(string msg,string uID)
        /// <summary>
        /// 将用户消息发给除了指定用户外的每一个在线用户
        /// </summary>
        /// <param name="msg">用户消息</param>
        /// <param name="uID">指定不接收消息的用户</param>
        public void SendMsgUserToEveryoneButOne(string msg,string uID,MsgType type)
        {
            if (msg.Length < 1) return;//如果长度小于3则终止方法
            foreach (string key in dictConnections.Keys)
            {
                if (!key.Equals(uID)) dictConnections[key].SendMsgType(msg, type);
            }
        }
        #endregion

        #region 将用户消息发给指定的在线用户 - SendMsgUserToSingle(string toUid, string msg, MsgType type)
        /// <summary>
        /// 将用户消息发给指定的在线用户
        /// </summary>
        /// <param name="toUid">指定用户ID</param>
        /// <param name="msg">消息</param>
        /// <param name="type">消息类型</param>
        public void SendMsgUserToSingle(string toUid, string msg, MsgType type)
        {
            if (msg.Length < 1) return;//如果长度小于3则终止方法
            dictConnections[toUid].SendMsgType(msg, type);
        }
        #endregion

        #region 获得在线列表 - GetOnlineUserList()
        /// <summary>
        /// 获得在线列表
        /// </summary>
        /// <returns></returns>
        public string GetOnlineUserList()
        {
            string[] s = new string[dictConnections.Keys.Count];
            dictConnections.Keys.CopyTo(s, 0);
            return string.Join("|", s);
            //StringBuilder sb = new StringBuilder();
            //foreach (string key in dictConnections.Keys)
            //{
            //    sb.Append(key);
            //    sb.Append("|");
            //}
            //return sb.ToString();
        } 
        #endregion

        #region -添加在线人数
        /// <summary>
        /// 添加在线人数
        /// </summary>
        private void AddOnlineCount()
        {
            countOnline++;
            txtNowCount.Text = countOnline.ToString();
        } 
        #endregion

        #region -减少在线人数
        /// <summary>
        /// 减少在线人数
        /// </summary>
        private void SubtractOnlineCount()
        {
            countOnline--;
            txtNowCount.Text = countOnline.ToString();
        }
        #endregion

        #region -向在线列表添加项
        /// <summary>
        /// 向在线列表添加项
        /// </summary>
        /// <param name="uID"></param>
        private void AddClientToList(string uID)
        {
            ListViewItem lvi = new ListViewItem(uID);
            lvi.Tag = uID;
            lvFriends.Items.Add(lvi);
        } 
        #endregion

        #region 从在线列表中移除指定项
        /// <summary>
        /// 从在线在线列表中移除指定项
        /// </summary>
        /// <param name="uID"></param>
        public void RemoveListItem(string uID)
        {
            for (int i = 0; i < lvFriends.Items.Count; i++)
            {
                if (lvFriends.Items[i].Tag.ToString().Equals(uID))
                {
                    lvFriends.Items.RemoveAt(i);
                    break;
                }
            }
            RemoveConnection(uID);
            SendUserListToEveryone();
        } 
        #endregion

        #region -清空所有字典中保存的客户端连接对象 - ClearConnection()
        /// <summary>
        /// 清空所有字典中保存的客户端连接对象
        /// </summary>
        private void ClearConnection()
        {
            foreach (string key in new List<string>(dictConnections.Keys))
            {
                dictConnections[key].Close();
            }
            countOnline = 0;
            dictConnections.Clear();
        } 
        #endregion

        #region 从集合中移除连接 - RemoveConnection(string key)
        /// <summary>
        /// 从集合中移除连接
        /// </summary>
        /// <param name="key"></param>
        public void RemoveConnection(string key)
        {
            if (dictConnections.ContainsKey(key))
            {
                dictConnections[key].Close();
                dictConnections.Remove(key);
                SubtractOnlineCount();
            }
        } 
        #endregion

        #region -发送消息
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            GetSelectedUser().SendMsgType(txtInput.Text.Trim(), MsgType.UserMsg);
        }
        #endregion

        #region 获得选中的用户连接对象
        /// <summary>
        /// 获得选中的用户连接对象
        /// </summary>
        /// <returns></returns>
        private ClientConnection GetSelectedUser()
        {
            return lvFriends.SelectedItems.Count > 0 ? dictConnections[lvFriends.SelectedItems[0].Tag.ToString()] : null;
        } 
        #endregion

        #region -关闭并退出
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗?", "系统提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (sokWatchPort != null)
                {
                    SendSysQuitMsgToEveryone();
                    ClearConnection();
                    sokWatchPort.Close();
                    threadWatchPort.Abort();
                    dgShowMsg = null;
                }
                Application.Exit();
            }
        } 
        #endregion

        #region 暂停或恢复
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text.Equals("暂停"))
            {
                btnPause.Text = "恢复";
            }
            else
            {
                btnPause.Text = "暂停";
            }
        } 
        #endregion

        #region 修改负荷人数限制
        private void cboMaxCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int limitOnline = Convert.ToInt32(cboMaxCount.SelectedItem);
            if (limitOnline < countOnline)
            {
                ShowLog("对不起，您不能把负载调到少于当前在线人数! : (");
            }
            else
            {
                countLimite = limitOnline;
                ShowLog("当前负载已经设置成"+countLimite.ToString()+"人 : )");
            }
        } 
        #endregion

        #region 获得选中的用户ID - GetSelectedUserID()
        /// <summary>
        /// 获得选中的用户ID
        /// </summary>
        /// <returns></returns>
        private string GetSelectedUserID()
        {
            return lvFriends.SelectedItems.Count > 0 ? lvFriends.SelectedItems[0].Tag.ToString() : string.Empty;
        }
        #endregion

        #region 在发送消息前检查是否选中聊天对象 - CheckBeforeSend()
        /// <summary>
        /// 在发送消息前检查是否选中聊天对象
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeSend()
        {
            if (GetSelectedUserID() == string.Empty) { ShowMsg("您还未选择对象！"); return false; }
            else return true;
        }
        #endregion

        #region 踢人 - btnKickOut_Click
        private void btnKickOut_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend())
            {
                string selectedUserId = GetSelectedUserID();
                dictConnections[selectedUserId].SendMsgType(txtPunish.Text, MsgType.SysBeKickOut);
                SendMsgUserToEveryoneButOne(txtPunish.Text + "|" + selectedUserId, selectedUserId, MsgType.SysKickedOne);
                RemoveListItem(selectedUserId);
                ShowMsg("【" + selectedUserId + "】因【" + txtPunish.Text + "】已经被踢出聊天室......");
            }
        } 
        #endregion

        #region 禁言 - btnNoTalk_Click
        private void btnNoTalk_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend())
            {
                string selectedUserId = GetSelectedUserID();
                dictConnections[selectedUserId].SendMsgType(txtPunish.Text, MsgType.SysBeForbid);
                dictConnections[selectedUserId].User.IsForbidTalk=true;
                SendMsgUserToEveryoneButOne(txtPunish.Text + "|" + selectedUserId, selectedUserId, MsgType.SysForbidOne);
                ShowMsg("【" + selectedUserId + "】因【" + txtPunish.Text + "】已经被禁止发言......");
            }
        } 
        #endregion

        #region 恢复发言 - btnYesTalk_Click
        private void btnYesTalk_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend())
            {
                string selectedUserId = GetSelectedUserID();
                ClientConnection nowConn = dictConnections[selectedUserId];
                if (nowConn.User.Statu == UserStatu.BeForbid)
                {
                    nowConn.SendMsgType(txtPunish.Text, MsgType.SysNoForbid);
                    nowConn.User.IsForbidTalk = false;
                    SendMsgUserToEveryoneButOne(txtPunish.Text + "|" + selectedUserId, selectedUserId, MsgType.SysNoForbidOne);
                    ShowMsg("【" + selectedUserId + "】因【" + txtPunish.Text + "】已经被解除禁言......");
                }
            }
        }
        #endregion

        #region 警告 - btnWarning_Click
        private void btnWarning_Click(object sender, EventArgs e)
        {
            if (CheckBeforeSend())
            {
                string selectedUserId = GetSelectedUserID();
                dictConnections[selectedUserId].SendMsgType(txtPunish.Text, MsgType.SysBeWarning);
                SendMsgUserToEveryoneButOne(txtPunish.Text + "|" + selectedUserId, selectedUserId, MsgType.SysWarningOne);
                ShowMsg("【" + selectedUserId + "】因【" + txtPunish.Text + "】被警告了......");
            }
        } 
        #endregion

        private void btnClearShow_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";
        }
    }
}