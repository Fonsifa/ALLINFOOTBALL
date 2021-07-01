using System;
using System.Collections.Generic;
using System.Text;

namespace FeiMsgType
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// 用户消息
        /// </summary>
        UserMsg=0,
        /// <summary>
        /// 用户文件
        /// </summary>
        UserFile = 1,
        /// <summary>
        /// 系统消息-用户退出
        /// </summary>
        SysMsgUserQuit = 2,
        /// <summary>
        /// 连接消息
        /// </summary>
        ConnectMsg=3,
        /// <summary>
        /// 抖动窗体
        /// </summary>
        UserShake=4,
        /// <summary>
        /// 在线列表
        /// </summary>
        OnlineList=5,
        /// <summary>
        /// 在线负载限制
        /// </summary>
        SysMsgOnlineLimit=6,
        /// <summary>
        /// 系统消息
        /// </summary>
        SysMsg=7,
        /// <summary>
        /// 服务器退出
        /// </summary>
        SysQuit=8,
        /// <summary>
        /// 用户发送文件
        /// </summary>
        UserFileSend=9,
        /// <summary>
        /// 用户接收文件
        /// </summary>
        UserFileRec = 10,
        /// <summary>
        /// 用户拒绝接收文件
        /// </summary>
        UserFileRefuse=11,
        /// <summary>
        /// 踢出聊天室
        /// </summary>
        SysBeKickOut=12,
        /// <summary>
        /// 有人被踢出聊天室了
        /// </summary>
        SysKickedOne = 13,
        /// <summary>
        /// 禁止某人发言
        /// </summary>
        SysBeForbid = 14,
        /// <summary>
        /// 有人被禁止发言了
        /// </summary>
        SysForbidOne=15,
        /// <summary>
        /// 解除禁言
        /// </summary>
        SysNoForbid=16,
        /// <summary>
        /// 有人被解除禁言了
        /// </summary>
        SysNoForbidOne=17,
        /// <summary>
        /// 警告
        /// </summary>
        SysBeWarning=18,
        /// <summary>
        /// 有人被警告了
        /// </summary>
        SysWarningOne=19
    }
}
