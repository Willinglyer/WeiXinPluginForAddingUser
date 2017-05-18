using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysss
{
    public class CurrentPhoneInfo
    {
        /// <summary>
        /// 当前线程ID
        /// </summary>
        public int CurrentThreadID { get; set; }
        /// <summary>
        /// 当前手机的名称
        /// </summary>
        public string PhoneName { get; set; }
        /// <summary>
        /// 当前手机进行到的轮数
        /// </summary>
        public int CircleNum { get; set; }
        /// <summary>
        /// 当前手机已加好友数
        /// </summary>
        public int AddedNum { get; set; }
        /// <summary>
        /// 当前手机的执行状态
        /// </summary>
        public string State { get; set; }
    }
}
