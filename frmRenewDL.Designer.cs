namespace DVLManagementSystem
{
    partial class frmRenewDL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenewDL));
            this.linkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklblShowLicenceInfo = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchLicenseID = new System.Windows.Forms.TextBox();
            this.filterLicense1 = new DVLManagementSystem.filterLicense();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkShowLicenseHistory
            // 
            this.linkShowLicenseHistory.AutoSize = true;
            this.linkShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkShowLicenseHistory.Location = new System.Drawing.Point(754, 642);
            this.linkShowLicenseHistory.Name = "linkShowLicenseHistory";
            this.linkShowLicenseHistory.Size = new System.Drawing.Size(157, 20);
            this.linkShowLicenseHistory.TabIndex = 26;
            this.linkShowLicenseHistory.TabStop = true;
            this.linkShowLicenseHistory.Text = "ShowLicense History";
            this.linkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicenseHistory_LinkClicked);
            // 
            // linklblShowLicenceInfo
            // 
            this.linklblShowLicenceInfo.AutoSize = true;
            this.linklblShowLicenceInfo.Enabled = false;
            this.linklblShowLicenceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicenceInfo.Location = new System.Drawing.Point(762, 613);
            this.linklblShowLicenceInfo.Name = "linklblShowLicenceInfo";
            this.linklblShowLicenceInfo.Size = new System.Drawing.Size(140, 20);
            this.linklblShowLicenceInfo.TabIndex = 27;
            this.linklblShowLicenceInfo.TabStop = true;
            this.linklblShowLicenceInfo.Text = "Show Licence Info";
            this.linklblShowLicenceInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenceInfo_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(788, 517);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 36);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Renew";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(788, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtSearchLicenseID);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 66);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "License ID:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchLicenseID
            // 
            this.txtSearchLicenseID.Location = new System.Drawing.Point(99, 27);
            this.txtSearchLicenseID.Name = "txtSearchLicenseID";
            this.txtSearchLicenseID.Size = new System.Drawing.Size(176, 24);
            this.txtSearchLicenseID.TabIndex = 0;
            // 
            // filterLicense1
            // 
            this.filterLicense1.Location = new System.Drawing.Point(12, 90);
            this.filterLicense1.Name = "filterLicense1";
            this.filterLicense1.Size = new System.Drawing.Size(744, 647);
            this.filterLicense1.TabIndex = 29;
            this.filterLicense1.Load += new System.EventHandler(this.filterLicense1_Load);
            // 
            // frmRenewDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 749);
            this.Controls.Add(this.filterLicense1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkShowLicenseHistory);
            this.Controls.Add(this.linklblShowLicenceInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenewDL";
            this.Load += new System.EventHandler(this.frmRenewDL_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linklblShowLicenceInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.TextBox txtSearchLicenseID;
        private filterLicense filterLicense1;
    }
}