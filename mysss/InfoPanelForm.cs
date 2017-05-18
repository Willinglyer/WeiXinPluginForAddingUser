using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysss
{
    public delegate void MainClassFoo(ref AutoAddPeopleNoForbbid mcf,ref BindingList<CurrentPhoneInfo> addedPhoneList);
    public partial class InfoPanelForm : Form
    {
        private AutoAddPeopleNoForbbid mcf;
        private BindingList<CurrentPhoneInfo> addedPhoneList;

        public event MainClassFoo mcfEvent;

        public InfoPanelForm()
        {
            InitializeComponent();
        }

        public void setMainClass()
        {
            this.mcfEvent(ref this.mcf, ref this.addedPhoneList);
            this.mcf.ModifyAddedNum += this.updateShowing;  //传递方法指针进去，让数据进到窗体里面来（这样子，通过委托和事件，实现了跨线程的传值…………）
        }

        //根据外部传递进来的数据，给当前窗体的属性赋值
        private void updateShowing(object sender, AddedTotalNumEventArgs e) {

            if (this.InvokeRequired)    //如果需要UI线程，则切换
            {
                this.Invoke(new Action(() =>
                {
                    this.lbl_totalNum.Text = e.AddedTotalNum;
                    this.lbl_AddedNum.Text = e.AddedNum;
                    this.lbl_noAddedNum.Text = e.NoAddedNum;
                    this.lbl_AddedPercent.Text = e.AddedPercent;
                }));
            }
            else
            {
                this.lbl_totalNum.Text = e.AddedTotalNum;
                this.lbl_AddedNum.Text = e.AddedNum;
                this.lbl_noAddedNum.Text = e.NoAddedNum;
                this.lbl_AddedPercent.Text = e.AddedPercent;
            }
        }

        private void btn_ShowEveryPhoneState_Click(object sender, EventArgs e)
        {
            FrmShowEveryPhoneState fShowState = new FrmShowEveryPhoneState(ref this.addedPhoneList);
            //展示窗体
            fShowState.Show();
        }
    };
}
