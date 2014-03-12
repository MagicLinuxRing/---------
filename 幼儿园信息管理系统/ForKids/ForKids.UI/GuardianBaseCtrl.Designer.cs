namespace ForKids.UI
{
    partial class GuardianBaseCtrl
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
            this.button_delete = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_date)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_date
            // 
            this.dataGridView_date.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_date.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_date.Location = new System.Drawing.Point(0, 55);
            this.dataGridView_date.Name = "dataGridView_date";
            this.dataGridView_date.RowTemplate.Height = 23;
            this.dataGridView_date.Size = new System.Drawing.Size(522, 261);
            this.dataGridView_date.TabIndex = 0;
            // 
            // button_delete
            // 
            this.button_delete.Image = global::ForKids.UI.Properties.Resources.delete;
            this.button_delete.Location = new System.Drawing.Point(105, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(45, 45);
            this.button_delete.TabIndex = 1;
            this.button_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_edit
            // 
            this.button_edit.Image = global::ForKids.UI.Properties.Resources.edit;
            this.button_edit.Location = new System.Drawing.Point(54, 4);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(45, 45);
            this.button_edit.TabIndex = 1;
            this.button_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_add
            // 
            this.button_add.Image = global::ForKids.UI.Properties.Resources.add;
            this.button_add.Location = new System.Drawing.Point(3, 4);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(45, 45);
            this.button_add.TabIndex = 1;
            this.button_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // GuardianBaseCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.dataGridView_date);
            this.Name = "GuardianBaseCtrl";
            this.Size = new System.Drawing.Size(522, 316);
            this.Load += new System.EventHandler(this.GuardianBaseCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_date)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_date;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_delete;
    }
}
