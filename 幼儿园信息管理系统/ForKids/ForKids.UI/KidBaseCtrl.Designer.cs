namespace ForKids.UI
{
    partial class KidBaseCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_date = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_date)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_date
            // 
            this.dataGridView_date.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_date.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_date.Name = "dataGridView_date";
            this.dataGridView_date.RowTemplate.Height = 23;
            this.dataGridView_date.Size = new System.Drawing.Size(522, 316);
            this.dataGridView_date.TabIndex = 0;
            // 
            // KidBaseCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_date);
            this.Name = "KidBaseCtrl";
            this.Size = new System.Drawing.Size(522, 316);
            this.Load += new System.EventHandler(this.KidBaseCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_date)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_date;
    }
}
