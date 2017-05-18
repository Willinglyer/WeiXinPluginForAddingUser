namespace mysss
{
    partial class FrmSetLQ
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
            this.lbx_lQ = new System.Windows.Forms.ListBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tbx_lQItem = new System.Windows.Forms.TextBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbx_lQ
            // 
            this.lbx_lQ.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbx_lQ.FormattingEnabled = true;
            this.lbx_lQ.ItemHeight = 19;
            this.lbx_lQ.Items.AddRange(new object[] {
            "01",
            "02",
            "03"});
            this.lbx_lQ.Location = new System.Drawing.Point(143, 18);
            this.lbx_lQ.Name = "lbx_lQ";
            this.lbx_lQ.Size = new System.Drawing.Size(154, 270);
            this.lbx_lQ.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Location = new System.Drawing.Point(28, 84);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 39);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tbx_lQItem
            // 
            this.tbx_lQItem.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_lQItem.Location = new System.Drawing.Point(6, 27);
            this.tbx_lQItem.Multiline = true;
            this.tbx_lQItem.Name = "tbx_lQItem";
            this.tbx_lQItem.Size = new System.Drawing.Size(131, 49);
            this.tbx_lQItem.TabIndex = 2;
            this.tbx_lQItem.Text = "这里输入快照名称（推荐英文）";
            this.tbx_lQItem.Enter += new System.EventHandler(this.tbx_lQItem_Enter);
            // 
            // btn_Delete
            // 
            this.btn_Delete.ForeColor = System.Drawing.Color.Red;
            this.btn_Delete.Location = new System.Drawing.Point(22, 138);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(93, 34);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "删除选定项";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(28, 224);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 64);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "确认设置";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.ForeColor = System.Drawing.Color.Red;
            this.btn_ClearAll.Location = new System.Drawing.Point(22, 178);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(93, 34);
            this.btn_ClearAll.TabIndex = 3;
            this.btn_ClearAll.Text = "全部清空";
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // FrmSetLQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 307);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_ClearAll);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.tbx_lQItem);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lbx_lQ);
            this.Name = "FrmSetLQ";
            this.Text = "FrmSetLQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_lQ;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox tbx_lQItem;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_ClearAll;
    }
}