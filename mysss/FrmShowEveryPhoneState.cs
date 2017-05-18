using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysss
{
    /// <summary>
    /// 展示每个手机号的状态
    /// </summary>
    public partial class FrmShowEveryPhoneState : Form
    {
        //要展示的每个手机号的状态信息
        public FrmShowEveryPhoneState(ref BindingList<CurrentPhoneInfo> addedPhoneList)
        {
            InitializeComponent();

            dgv_ShowEveryPhoneInfo.DataSource = addedPhoneList;
            //如果检测得到变化，则动态展示addedPhoneList 中的数据
            dgv_ShowEveryPhoneInfo.Columns[0].Visible = false;

            //设置列标题
            dgv_ShowEveryPhoneInfo.Columns[1].HeaderText = "手机名称";
            dgv_ShowEveryPhoneInfo.Columns[2].HeaderText = "进行到的轮数";
            dgv_ShowEveryPhoneInfo.Columns[3].HeaderText = "已加好友数";
            dgv_ShowEveryPhoneInfo.Columns[4].HeaderText = "手机状态";
        }
    };
}
