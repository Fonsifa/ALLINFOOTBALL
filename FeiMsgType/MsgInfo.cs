using System;
using System.Collections.Generic;
using System.Text;

namespace FeiMsgType
{
    /// <summary>
    /// 消息-相关信息(myUid,toUid,privateTalk,mood|msg)
    /// </summary>
    [Serializable]
    public class MsgInfo
    {
        public MsgInfo() { }

        /// <summary>
        /// 将消息字符串转成 MsgInfo 对象 - 传递用户聊天消息时使用
        /// </summary>
        /// <param name="msgOri">消息字符串</param>
        public MsgInfo(string msgOri)
        {
            string[] msgInfo = msgOri.Split('|');
            content = msgInfo[1];
            msgInfo = msgInfo[0].Split(',');
            if (msgInfo.Length > 1)
            {
                uId = msgInfo[0];
                toUid = msgInfo[1];
                isPrivate = bool.Parse(msgInfo[2]);
                mood = msgInfo[3];
            }
        }

        #region +获得在客户端待显示的格式化字符串 - ToSayInClient()
        /// <summary>
        /// 获得在客户端待显示的格式化字符串
        /// </summary>
        /// <returns></returns>
        public string ToSayInClient(string hostID)
        {
            return "【" + (UId.Equals(hostID) ? "你" : UId) + "】对【" + (ToUid == string.Empty ? "所有人" : hostID.Equals(ToUid) ? "你" : ToUid) + "】" + (IsPrivate ? "悄悄地 " : "") + Mood + " 说：" + Content;
        } 
        #endregion

        #region +获得在服务端待显示的格式化字符串 - ToSayInServerTextBox()
        /// <summary>
        /// 获得在服务端待显示的格式化字符串
        /// </summary>
        /// <returns></returns>
        public string ToSayInServerTextBox()
        {
            return "【" + UId + "】对【" + (ToUid == string.Empty ? "所有人" : ToUid) + "】" + (IsPrivate ? "悄悄地 " : "") + Mood + " 说：" + Content;
        }
        #endregion

        #region +返回待传输的格式化字符串(格式：发送者ID，接收者ID，是否私聊，表情|内容) - ToTransString()
        /// <summary>
        /// 获得待传输的格式化字符串(格式：发送者ID,接收者ID,是否私聊,表情|内容)
        /// </summary>
        /// <returns>发送者ID,接收者ID,是否私聊,表情 | 内容</returns>
        public string ToTransString()
        {
            return UId + "," + ToUid + "," + IsPrivate+ "," + Mood + "|" + Content;
        } 
        #endregion

        #region +获得待待发送的带类型的消息字节数组 - ToByteArrTypeMsg(string originalStr, MsgType type)
        /// <summary>
        /// 获得待待发送的带类型的消息字节数组
        /// </summary>
        /// <param name="originalStr">字符串</param>
        /// <param name="type">消息类型</param>
        /// <returns></returns>
        public static byte[] ToByteArrTypeMsg(string originalStr, MsgType type)
        {
            byte[] orgByte = Encoding.UTF8.GetBytes(originalStr);
            byte[] finalByte = new byte[orgByte.Length + 1];
            finalByte[0] = (byte)type;
            Buffer.BlockCopy(orgByte, 0, finalByte, 1, orgByte.Length);
            return finalByte;
        }
        #endregion

        #region 消息类型
        private MsgType type;
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgType Type
        {
            get { return type; }
            set { type = value; }
        } 
        #endregion

        #region 消息发送者ID
        private string uId = string.Empty;
        /// <summary>
        /// 消息发送者ID
        /// </summary>
        public string UId
        {
            get { return uId; }
            set { uId = value; }
        } 
        #endregion

        #region 接收者ID
        private string toUid=string.Empty;
        /// <summary>
        /// 接收者ID
        /// </summary>
        public string ToUid
        {
            get { return toUid; }
            set { toUid = value; }
        } 
        #endregion

        #region 是否私聊
        private bool isPrivate;
        /// <summary>
        /// 是否私聊
        /// </summary>
        public bool IsPrivate
        {
            get { return isPrivate; }
            set { isPrivate = value; }
        } 
        #endregion

        #region 表情
        private string mood = string.Empty;
        /// <summary>
        /// 表情
        /// </summary>
        public string Mood
        {
            get { return mood; }
            set { mood = value; }
        } 
        #endregion

        #region 消息内容
        private string content = string.Empty;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        } 
        #endregion
    }
}
