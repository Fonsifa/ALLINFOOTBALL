using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FeiMsgType
{
    [Serializable, AttributeUsage(AttributeTargets.Delegate | AttributeTargets.Interface | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Class, Inherited = false), ComVisible(true)]
    public sealed class PromptAttribute:Attribute
    {
        // Fields
        private bool _error;
        private string _message;

        // Methods
        public PromptAttribute()
        {
            this._message = null;
            this._error = false;
        }

        public PromptAttribute(string message)
        {
            this._message = message;
            this._error = false;
        }

        public PromptAttribute(string message, bool error)
        {
            this._message = message;
            this._error = error;
        }

        // Properties
        public bool IsError
        {
            get
            {
                return this._error;
            }
        }

        public string Message
        {
            get
            {
                return this._message;
            }
        }
    }
}
