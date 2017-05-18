using System;

namespace mysss
{
    public class AddedTotalNumEventArgs : EventArgs
    {
        //  总共需要加的  手机号个数
        public string AddedTotalNum { get; set; }
        //  已加的 手机号个数
        public string AddedNum { get; set; }
        //  未加的手机号个数
        public string NoAddedNum { get; set; }
        //  已加 所占百分比
        public string AddedPercent { get; set; }
    }
}
