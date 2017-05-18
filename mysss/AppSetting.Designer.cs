namespace mysss
{
    partial class AppSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_OneHour = new System.Windows.Forms.TextBox();
            this.txt_waitOneHourNum = new System.Windows.Forms.TextBox();
            this.txt_waitOneDayNum = new System.Windows.Forms.TextBox();
            this.txt_validateContext = new System.Windows.Forms.TextBox();
            this.btn_EnableModifyHour = new System.Windows.Forms.Button();
            this.dlg_fileOpen = new System.Windows.Forms.OpenFileDialog();
            this.btn_chooseATxt = new System.Windows.Forms.Button();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_maxWait = new System.Windows.Forms.TextBox();
            this.txt_minWait = new System.Windows.Forms.TextBox();
            this.btn_SetLQ = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(352, 294);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 39);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "确认设置";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "等待一小时的毫秒数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "每一轮加的人数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "每次运行加的轮数（运行完，就停止）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "加好友时，验证信息的内容：";
            // 
            // txt_OneHour
            // 
            this.txt_OneHour.Enabled = false;
            this.txt_OneHour.Location = new System.Drawing.Point(238, 36);
            this.txt_OneHour.Name = "txt_OneHour";
            this.txt_OneHour.Size = new System.Drawing.Size(93, 21);
            this.txt_OneHour.TabIndex = 2;
            this.txt_OneHour.Text = "3600";
            // 
            // txt_waitOneHourNum
            // 
            this.txt_waitOneHourNum.Location = new System.Drawing.Point(238, 96);
            this.txt_waitOneHourNum.Name = "txt_waitOneHourNum";
            this.txt_waitOneHourNum.Size = new System.Drawing.Size(52, 21);
            this.txt_waitOneHourNum.TabIndex = 2;
            this.txt_waitOneHourNum.Text = "1";
            // 
            // txt_waitOneDayNum
            // 
            this.txt_waitOneDayNum.Location = new System.Drawing.Point(238, 136);
            this.txt_waitOneDayNum.Name = "txt_waitOneDayNum";
            this.txt_waitOneDayNum.Size = new System.Drawing.Size(52, 21);
            this.txt_waitOneDayNum.TabIndex = 2;
            this.txt_waitOneDayNum.Text = "2";
            // 
            // txt_validateContext
            // 
            this.txt_validateContext.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_validateContext.Location = new System.Drawing.Point(238, 199);
            this.txt_validateContext.Multiline = true;
            this.txt_validateContext.Name = "txt_validateContext";
            this.txt_validateContext.Size = new System.Drawing.Size(190, 42);
            this.txt_validateContext.TabIndex = 2;
            this.txt_validateContext.Text = "嗨！";
            // 
            // btn_EnableModifyHour
            // 
            this.btn_EnableModifyHour.Location = new System.Drawing.Point(352, 34);
            this.btn_EnableModifyHour.Name = "btn_EnableModifyHour";
            this.btn_EnableModifyHour.Size = new System.Drawing.Size(76, 28);
            this.btn_EnableModifyHour.TabIndex = 0;
            this.btn_EnableModifyHour.Text = "允许修改";
            this.btn_EnableModifyHour.UseVisualStyleBackColor = true;
            this.btn_EnableModifyHour.Click += new System.EventHandler(this.btn_EnableModifyHour_Click);
            // 
            // dlg_fileOpen
            // 
            this.dlg_fileOpen.FileName = "openFileDialog1";
            // 
            // btn_chooseATxt
            // 
            this.btn_chooseATxt.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_chooseATxt.Location = new System.Drawing.Point(89, 280);
            this.btn_chooseATxt.Name = "btn_chooseATxt";
            this.btn_chooseATxt.Size = new System.Drawing.Size(133, 39);
            this.btn_chooseATxt.TabIndex = 0;
            this.btn_chooseATxt.Text = "选择txt文件";
            this.btn_chooseATxt.UseVisualStyleBackColor = true;
            this.btn_chooseATxt.Click += new System.EventHandler(this.btn_chooseATxt_Click);
            // 
            // txt_fileName
            // 
            this.txt_fileName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_fileName.Location = new System.Drawing.Point(21, 325);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(282, 21);
            this.txt_fileName.TabIndex = 2;
            this.txt_fileName.Text = "选择的文件名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_maxWait);
            this.groupBox1.Controls.Add(this.txt_minWait);
            this.groupBox1.Location = new System.Drawing.Point(321, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "随机等待范围";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(93, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "上限";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(28, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "下限";
            // 
            // txt_maxWait
            // 
            this.txt_maxWait.Location = new System.Drawing.Point(75, 41);
            this.txt_maxWait.Name = "txt_maxWait";
            this.txt_maxWait.Size = new System.Drawing.Size(59, 21);
            this.txt_maxWait.TabIndex = 0;
            this.txt_maxWait.Text = "30";
            this.txt_maxWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_minWait
            // 
            this.txt_minWait.Location = new System.Drawing.Point(17, 41);
            this.txt_minWait.Name = "txt_minWait";
            this.txt_minWait.Size = new System.Drawing.Size(52, 21);
            this.txt_minWait.TabIndex = 0;
            this.txt_minWait.Text = "10";
            this.txt_minWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SetLQ
            // 
            this.btn_SetLQ.Location = new System.Drawing.Point(355, 251);
            this.btn_SetLQ.Name = "btn_SetLQ";
            this.btn_SetLQ.Size = new System.Drawing.Size(104, 30);
            this.btn_SetLQ.TabIndex = 4;
            this.btn_SetLQ.Text = "设置轮切列表";
            this.btn_SetLQ.UseVisualStyleBackColor = true;
            this.btn_SetLQ.Click += new System.EventHandler(this.btn_SetLQ_Click);
            // 
            // AppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 358);
            this.Controls.Add(this.btn_SetLQ);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_validateContext);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.txt_waitOneDayNum);
            this.Controls.Add(this.txt_waitOneHourNum);
            this.Controls.Add(this.txt_OneHour);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_EnableModifyHour);
            this.Controls.Add(this.btn_chooseATxt);
            this.Controls.Add(this.btn_OK);
            this.Name = "AppSetting";
            this.Text = "设置初始参数";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_OneHour;
        private System.Windows.Forms.TextBox txt_waitOneHourNum;
        private System.Windows.Forms.TextBox txt_waitOneDayNum;
        private System.Windows.Forms.TextBox txt_validateContext;
        private System.Windows.Forms.Button btn_EnableModifyHour;
        private System.Windows.Forms.OpenFileDialog dlg_fileOpen;
        private System.Windows.Forms.Button btn_chooseATxt;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_maxWait;
        private System.Windows.Forms.TextBox txt_minWait;
        private System.Windows.Forms.Button btn_SetLQ;
    }
}