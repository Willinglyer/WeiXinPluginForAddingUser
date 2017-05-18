namespace mysss
{
    partial class FrmShowEveryPhoneState
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_ShowEveryPhoneInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowEveryPhoneInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ShowEveryPhoneInfo
            // 
            this.dgv_ShowEveryPhoneInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_ShowEveryPhoneInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowEveryPhoneInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShowEveryPhoneInfo.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShowEveryPhoneInfo.Name = "dgv_ShowEveryPhoneInfo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ShowEveryPhoneInfo.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ShowEveryPhoneInfo.RowTemplate.Height = 23;
            this.dgv_ShowEveryPhoneInfo.Size = new System.Drawing.Size(538, 345);
            this.dgv_ShowEveryPhoneInfo.TabIndex = 0;
            // 
            // FrmShowEveryPhoneState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 345);
            this.Controls.Add(this.dgv_ShowEveryPhoneInfo);
            this.Name = "FrmShowEveryPhoneState";
            this.Text = "FrmShowEveryPhoneState";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowEveryPhoneInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ShowEveryPhoneInfo;
    }
}