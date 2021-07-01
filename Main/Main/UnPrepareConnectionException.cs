using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    /// <summary>
    /// 未准备好的连接异常
    /// </summary>
    public class UnPrepareConnectionException: Exception
    {
        public override string Message
        {
            get
            {
                return "连接初始化参数为NULL! (base.Message="+base.Message+")";
            }
        }
    }
}
