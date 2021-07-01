using System;
using System.Collections.Generic;
using System.Text;

namespace FeiMsgType
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class ClientUser
    {
        public ClientUser() { }
        public ClientUser(string uId,string uName)
        {
            id = uId;
            name = uName;
        }

        #region 是否被禁止发言 - IsForbidTalk
        private bool isForbidTalk = false;
        /// <summary>
        /// 是否被禁止发言(自动设置用户状态属性)
        /// </summary>
        public bool IsForbidTalk
        {
            get { return isForbidTalk; }
            set
            {
                statu = (value ? UserStatu.BeForbid : UserStatu.OK);
                isForbidTalk = value;
            }
        } 
        #endregion

        #region 用户ID -ID
        private string id = string.Empty;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        } 
        #endregion

        #region 用户名 - Name
        private string name=string.Empty;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        } 
        #endregion

        #region 登录时间 - LoginTime
        private DateTime loginTime;
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        } 
        #endregion

        #region 用户状态(默认正常) - Statu
        private UserStatu statu= UserStatu.OK;
        /// <summary>
        /// 用户状态(默认正常) - 如果想获得状态字符串，可以使用属性StatuString
        /// </summary>
        public UserStatu Statu
        {
            get { return statu; }
            set { statu = value; }
        } 
        #endregion

        #region 用户状态字符串(默认正常) - StatuString
        /// <summary>
        /// 用户状态(默认正常)
        /// </summary>
        public string StatuString
        {
            get 
            {
                return statu == UserStatu.OK ? "正常" : "被禁言";
            }
        }
        #endregion

        #region 表情ID - FaceId
        private int faceId=1;
        /// <summary>
        /// 表情ID
        /// </summary>
        public int FaceId
        {
            get { return faceId; }
            set { faceId = value; }
        } 
        #endregion

        #region 性别 - Gender
        private bool gender=false;
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        } 
        #endregion

        #region 年龄 - Age
        private int age=18;
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get { return age; }
            set { age = value; }
        } 
        #endregion

        #region 电子邮箱 - Email
        private string email = string.Empty;
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        } 
        #endregion

        #region 备注 - Remark
        private string remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        } 
        #endregion
    }
}
