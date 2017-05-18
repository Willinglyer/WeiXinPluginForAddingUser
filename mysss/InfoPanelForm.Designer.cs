namespace mysss
{
    partial class InfoPanelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_totalNum = new System.Windows.Forms.Label();
            this.lbl_AddedNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_noAddedNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_AddedPercent = new System.Windows.Forms.Label();
            this.btn_ShowEveryPhoneState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(107, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前加载的手机号的总数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "已加的手机号的总数";
            // 
            // lbl_totalNum
            // 
            this.lbl_totalNum.AutoSize = true;
            this.lbl_totalNum.Font = new System.Drawing.Font("隶书", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_totalNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_totalNum.Location = new System.Drawing.Point(204, 38);
            this.lbl_totalNum.Name = "lbl_totalNum";
            this.lbl_totalNum.Size = new System.Drawing.Size(52, 56);
            this.lbl_totalNum.TabIndex = 0;
            this.lbl_totalNum.Text = "0";
            // 
            // lbl_AddedNum
            // 
            this.lbl_AddedNum.AutoSize = true;
            this.lbl_AddedNum.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_AddedNum.ForeColor = System.Drawing.Color.Orange;
            this.lbl_AddedNum.Location = new System.Drawing.Point(105, 129);
            this.lbl_AddedNum.Name = "lbl_AddedNum";
            this.lbl_AddedNum.Size = new System.Drawing.Size(33, 35);
            this.lbl_AddedNum.TabIndex = 0;
            this.lbl_AddedNum.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(276, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "未加的手机号的总数";
            // 
            // lbl_noAddedNum
            // 
            this.lbl_noAddedNum.AutoSize = true;
            this.lbl_noAddedNum.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_noAddedNum.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_noAddedNum.Location = new System.Drawing.Point(348, 129);
            this.lbl_noAddedNum.Name = "lbl_noAddedNum";
            this.lbl_noAddedNum.Size = new System.Drawing.Size(33, 35);
            this.lbl_noAddedNum.TabIndex = 0;
            this.lbl_noAddedNum.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(103, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "完成百分比：";
            // 
            // lbl_AddedPercent
            // 
            this.lbl_AddedPercent.AutoSize = true;
            this.lbl_AddedPercent.Font = new System.Drawing.Font("隶书", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_AddedPercent.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_AddedPercent.Location = new System.Drawing.Point(251, 194);
            this.lbl_AddedPercent.Name = "lbl_AddedPercent";
            this.lbl_AddedPercent.Size = new System.Drawing.Size(33, 35);
            this.lbl_AddedPercent.TabIndex = 0;
            this.lbl_AddedPercent.Text = "0";
            // 
            // btn_ShowEveryPhoneState
            // 
            this.btn_ShowEveryPhoneState.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ShowEveryPhoneState.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowEveryPhoneState.Location = new System.Drawing.Point(354, 230);
            this.btn_ShowEveryPhoneState.Name = "btn_ShowEveryPhoneState";
            this.btn_ShowEveryPhoneState.Size = new System.Drawing.Size(171, 29);
            this.btn_ShowEveryPhoneState.TabIndex = 1;
            this.btn_ShowEveryPhoneState.Text = "展示所有手机的加好友状态";
            this.btn_ShowEveryPhoneState.UseVisualStyleBackColor = true;
            this.btn_ShowEveryPhoneState.Click += new System.EventHandler(this.btn_ShowEveryPhoneState_Click);
            // 
            // InfoPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 259);
            this.Controls.Add(this.btn_ShowEveryPhoneState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_AddedPercent);
            this.Controls.Add(this.lbl_noAddedNum);
            this.Controls.Add(this.lbl_AddedNum);
            this.Controls.Add(this.lbl_totalNum);
            this.Controls.Add(this.label1);
            this.Name = "InfoPanelForm";
            this.Text = "InfoPanelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_totalNum;
        private System.Windows.Forms.Label lbl_AddedNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_noAddedNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_AddedPercent;
        private System.Windows.Forms.Button btn_ShowEveryPhoneState;
    }
}