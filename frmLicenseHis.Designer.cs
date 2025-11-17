namespace DVLManagementSystem
{
    partial class frmLicenseHis
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLHis = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvinterNLhis = new System.Windows.Forms.DataGridView();
            this.filter1 = new DVLManagementSystem.filter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHis)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvinterNLhis)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 388);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(818, 224);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLHis);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local License";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLHis
            // 
            this.dgvLHis.AllowUserToAddRows = false;
            this.dgvLHis.AllowUserToDeleteRows = false;
            this.dgvLHis.BackgroundColor = System.Drawing.Color.White;
            this.dgvLHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLHis.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLHis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLHis.Location = new System.Drawing.Point(3, 6);
            this.dgvLHis.Name = "dgvLHis";
            this.dgvLHis.ReadOnly = true;
            this.dgvLHis.Size = new System.Drawing.Size(804, 189);
            this.dgvLHis.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvinterNLhis);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(810, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International License";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvinterNLhis
            // 
            this.dgvinterNLhis.AllowUserToAddRows = false;
            this.dgvinterNLhis.AllowUserToDeleteRows = false;
            this.dgvinterNLhis.BackgroundColor = System.Drawing.Color.White;
            this.dgvinterNLhis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvinterNLhis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvinterNLhis.Location = new System.Drawing.Point(3, 6);
            this.dgvinterNLhis.Name = "dgvinterNLhis";
            this.dgvinterNLhis.ReadOnly = true;
            this.dgvinterNLhis.Size = new System.Drawing.Size(804, 189);
            this.dgvinterNLhis.TabIndex = 3;
            // 
            // filter1
            // 
            this.filter1.BackColor = System.Drawing.SystemColors.Control;
            this.filter1.Enabled = false;
            this.filter1.Location = new System.Drawing.Point(50, 15);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(755, 367);
            this.filter1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Show Licence Info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // frmLicenseHis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.filter1);
            this.Name = "frmLicenseHis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmLicenseHis_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLHis)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvinterNLhis)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private filter filter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvLHis;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvinterNLhis;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}