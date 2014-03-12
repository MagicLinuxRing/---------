namespace CRESDAMng.MetaDataCheckTool
{
    partial class DetailForm
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
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_name = new System.Windows.Forms.Panel();
            this.label_outputName = new System.Windows.Forms.Label();
            this.panel_container = new System.Windows.Forms.Panel();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.panel_main.SuspendLayout();
            this.panel_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.AutoScroll = true;
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.panel_name);
            this.panel_main.Controls.Add(this.panel_container);
            this.panel_main.Location = new System.Drawing.Point(5, 5);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(822, 378);
            this.panel_main.TabIndex = 0;
            this.panel_main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_main_Paint);
            // 
            // panel_name
            // 
            this.panel_name.Controls.Add(this.label_outputName);
            this.panel_name.Location = new System.Drawing.Point(13, 0);
            this.panel_name.Name = "panel_name";
            this.panel_name.Size = new System.Drawing.Size(91, 27);
            this.panel_name.TabIndex = 2;
            this.panel_name.SizeChanged += new System.EventHandler(this.panel_name_SizeChanged);
            // 
            // label_outputName
            // 
            this.label_outputName.AutoSize = true;
            this.label_outputName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_outputName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_outputName.Location = new System.Drawing.Point(3, 7);
            this.label_outputName.Name = "label_outputName";
            this.label_outputName.Size = new System.Drawing.Size(83, 12);
            this.label_outputName.TabIndex = 1;
            this.label_outputName.Text = "输出目录名：";
            this.label_outputName.TextChanged += new System.EventHandler(this.label_outputName_TextChanged);
            // 
            // panel_container
            // 
            this.panel_container.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_container.Location = new System.Drawing.Point(0, 29);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(800, 350);
            this.panel_container.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(671, 392);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "保存";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(752, 392);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // DetailForm
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(831, 421);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailForm";
            this.Text = "产品详细信息";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            this.SizeChanged += new System.EventHandler(this.DetailForm_SizeChanged);
            this.panel_main.ResumeLayout(false);
            this.panel_name.ResumeLayout(false);
            this.panel_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_outputName;
        private System.Windows.Forms.Panel panel_name;
    }
}