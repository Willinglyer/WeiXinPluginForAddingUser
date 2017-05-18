using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysss
{
    //设置初始化参数的 委托
    public delegate void loadAppSetting(int oneHour, int waitOneDayNum, int waitOneHourNum, string validateContext,string fileName,out bool hasLoadRight,int minWwait,int maxWait,List<string> lQArr);
    //用于执行加好友主体内容的 委托
    //public delegate void DoingAdding();
    //用于子线程给父线程窗口中的txt_fileName.text赋值
    public delegate void SetTxt_fileName(string fileName);

    public partial class AppSetting : Form
    {
        public event loadAppSetting loadAppSettingEvent;//声明 事件方法。
        //public event DoingAdding doingEvent;

        //用于使用OpenFileDialog的showDialog方法
        private Thread fileShowDialogThread;
        //执行加微信好友的核心线程
        //private Thread doingThread;

        //私有变量
        private List<string> lQArr = new List<string>(); //将在 轮切列表的窗口中进行实例化

        public AppSetting()
        {
            InitializeComponent();
        }

        private void btn_EnableModifyHour_Click(object sender, EventArgs e)
        {
            if (txt_OneHour.Enabled)
                btn_EnableModifyHour.Text = "允许修改";
            else
                btn_EnableModifyHour.Text = "禁止修改";
            txt_OneHour.Enabled = !txt_OneHour.Enabled;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txt_fileName.Text))
            {
                MessageBox.Show("请先指定文件名...........");
                return;
            }
            
            bool hasLoadRight;  //是否加载了有效的数据

            loadAppSettingEvent(Convert.ToInt32(txt_OneHour.Text),Convert.ToInt32(this.txt_waitOneDayNum.Text),Convert.ToInt32(this.txt_waitOneHourNum.Text),this.txt_validateContext.Text,this.txt_fileName.Text,out hasLoadRight,Convert.ToInt32(this.txt_minWait.Text),Convert.ToInt32(this.txt_maxWait.Text),this.lQArr);

            if (!hasLoadRight)
            {
                MessageBox.Show("指定文件中的内容为空，请重新指定一个文件.......");
                return;
            }

            MessageBox.Show("参数已设置！");

            this.Close();//关闭当前窗口

            //this.doingThread = new Thread(new ThreadStart(doingEvent));
            //doingThread.Start();

            //btn_Stop.Enabled = true;
        }

        //选择txt文件
        private void btn_chooseATxt_Click(object sender, EventArgs e)
        {
            //标题
            dlg_fileOpen.Title = "选择存有微信号的txt文件";
            //初始目录为程序运行根目录
            dlg_fileOpen.InitialDirectory = Directory.GetCurrentDirectory().ToString();
            //只读取txt文件
            dlg_fileOpen.Filter = "文本文件|*.txt";

            //返回用户选择的文件名
            fileShowDialogThread = new Thread(new ThreadStart(fileShowDialog));
            fileShowDialogThread.SetApartmentState(ApartmentState.STA);
            fileShowDialogThread.Start();
            fileShowDialogThread.Join();
        }

        //打开文件选择路径
        private void fileShowDialog() {
            if (dlg_fileOpen.ShowDialog() == DialogResult.OK)
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.txt_fileName.Text = dlg_fileOpen.FileName;
                }));
            }
        }

        /// <summary>
        /// 设置轮切列表
        /// </summary>
        /// <param name="sender">当前窗体</param>
        /// <param name="e">事件参数</param>
        private void btn_SetLQ_Click(object sender, EventArgs e)
        {
            //打开列表的设置窗口
            FrmSetLQ frmLQ = new FrmSetLQ(ref lQArr);
            frmLQ.ShowDialog();
        }
    };
}
