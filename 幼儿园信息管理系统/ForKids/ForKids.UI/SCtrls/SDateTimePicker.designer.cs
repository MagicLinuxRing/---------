namespace ForKids.UI.SCtrls
{
    partial class SDateTimePicker
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
            this._TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _TextBox
            // 
            this._TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._TextBox.Location = new System.Drawing.Point(0, 0);
            this._TextBox.Name = "_TextBox";
            this._TextBox.Size = new System.Drawing.Size(100, 14);
            this._TextBox.TabIndex = 0;
            this._TextBox.Leave += new System.EventHandler(this._TextBox_Leave);
            // 
            // SDateTimePicker
            // 
            this.ValueChanged += new System.EventHandler(this.SDateTimePicker_ValueChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _TextBox;
    }
}
