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
    public partial class FrmSetLQ : Form
    {
        private List<string> lQArr;

        public FrmSetLQ()
        {
            InitializeComponent();
        }

        public FrmSetLQ(ref List<string> lQArr) : this()
        {
            //初始化参数设置
            this.lQArr = lQArr;
        }

        /// <summary>
        /// 清空所有项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            this.lbx_lQ.Items.Clear();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.lbx_lQ.Items.Add(this.tbx_lQItem.Text);
        }

        /// <summary>
        /// 删除选定项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            this.lbx_lQ.Items.Remove(this.lbx_lQ.SelectedItem);
        }

        //确认设置，并关闭当前窗体
        private void btn_OK_Click(object sender, EventArgs e)
        {
            System.Collections.IEnumerator lqList = this.lbx_lQ.Items.GetEnumerator();
            while (lqList.MoveNext())
            {
                this.lQArr.Add((string)lqList.Current);
            }
            this.Close();
        }

        //获得焦点 则清空文字
        private void tbx_lQItem_Enter(object sender, EventArgs e)
        {
            this.tbx_lQItem.Clear();
        }
    };
}
