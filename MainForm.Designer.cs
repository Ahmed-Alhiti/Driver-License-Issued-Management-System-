namespace DVLManagementSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLostOrDamagedLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenesApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenesApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsLicennesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDtainedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleManagementToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 60);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detailsLicennesToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = global::DVLManagementSystem.Properties.Resources.list_view_50px;
            this.applicationsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(157, 56);
            this.applicationsToolStripMenuItem.Text = "Applications";
            this.applicationsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // drivToolStripMenuItem
            // 
            this.drivToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenesToolStripMenuItem,
            this.renewDrivingLicenesToolStripMenuItem,
            this.replacementForLostOrDamagedLicenesToolStripMenuItem,
            this.relToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivToolStripMenuItem.Name = "drivToolStripMenuItem";
            this.drivToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.drivToolStripMenuItem.Text = "Driving License Services";
            // 
            // newDrivingLicenesToolStripMenuItem
            // 
            this.newDrivingLicenesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenesToolStripMenuItem,
            this.internationalLicenesToolStripMenuItem});
            this.newDrivingLicenesToolStripMenuItem.Name = "newDrivingLicenesToolStripMenuItem";
            this.newDrivingLicenesToolStripMenuItem.Size = new System.Drawing.Size(378, 26);
            this.newDrivingLicenesToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenesToolStripMenuItem
            // 
            this.localLicenesToolStripMenuItem.Name = "localLicenesToolStripMenuItem";
            this.localLicenesToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.localLicenesToolStripMenuItem.Text = "Local Licenes";
            this.localLicenesToolStripMenuItem.Click += new System.EventHandler(this.localLicenesToolStripMenuItem_Click);
            // 
            // internationalLicenesToolStripMenuItem
            // 
            this.internationalLicenesToolStripMenuItem.Name = "internationalLicenesToolStripMenuItem";
            this.internationalLicenesToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.internationalLicenesToolStripMenuItem.Text = "International Licenes";
            this.internationalLicenesToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenesToolStripMenuItem_Click);
            // 
            // renewDrivingLicenesToolStripMenuItem
            // 
            this.renewDrivingLicenesToolStripMenuItem.Name = "renewDrivingLicenesToolStripMenuItem";
            this.renewDrivingLicenesToolStripMenuItem.Size = new System.Drawing.Size(378, 26);
            this.renewDrivingLicenesToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenesToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenesToolStripMenuItem_Click);
            // 
            // replacementForLostOrDamagedLicenesToolStripMenuItem
            // 
            this.replacementForLostOrDamagedLicenesToolStripMenuItem.Name = "replacementForLostOrDamagedLicenesToolStripMenuItem";
            this.replacementForLostOrDamagedLicenesToolStripMenuItem.Size = new System.Drawing.Size(378, 26);
            this.replacementForLostOrDamagedLicenesToolStripMenuItem.Text = "Replacement For Lost Or Damaged License";
            this.replacementForLostOrDamagedLicenesToolStripMenuItem.Click += new System.EventHandler(this.replacementForLostOrDamagedLicenesToolStripMenuItem_Click);
            // 
            // relToolStripMenuItem
            // 
            this.relToolStripMenuItem.Name = "relToolStripMenuItem";
            this.relToolStripMenuItem.Size = new System.Drawing.Size(378, 26);
            this.relToolStripMenuItem.Text = "Release Detained Driving License";
            this.relToolStripMenuItem.Click += new System.EventHandler(this.relToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(378, 26);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenesApplicationsToolStripMenuItem,
            this.internationalDrivingLicenesApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicenesApplicationsToolStripMenuItem
            // 
            this.localDrivingLicenesApplicationsToolStripMenuItem.Name = "localDrivingLicenesApplicationsToolStripMenuItem";
            this.localDrivingLicenesApplicationsToolStripMenuItem.Size = new System.Drawing.Size(367, 26);
            this.localDrivingLicenesApplicationsToolStripMenuItem.Text = "Local Driving Licenes Applications";
            this.localDrivingLicenesApplicationsToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenesApplicationsToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenesApplicationsToolStripMenuItem
            // 
            this.internationalDrivingLicenesApplicationsToolStripMenuItem.Name = "internationalDrivingLicenesApplicationsToolStripMenuItem";
            this.internationalDrivingLicenesApplicationsToolStripMenuItem.Size = new System.Drawing.Size(367, 26);
            this.internationalDrivingLicenesApplicationsToolStripMenuItem.Text = "International Driving Licenes Applications";
            this.internationalDrivingLicenesApplicationsToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenesApplicationsToolStripMenuItem_Click);
            // 
            // detailsLicennesToolStripMenuItem
            // 
            this.detailsLicennesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDtainedToolStripMenuItem,
            this.detainedLicenseToolStripMenuItem,
            this.relaseDetainedLicenseToolStripMenuItem});
            this.detailsLicennesToolStripMenuItem.Name = "detailsLicennesToolStripMenuItem";
            this.detailsLicennesToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.detailsLicennesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDtainedToolStripMenuItem
            // 
            this.manageDtainedToolStripMenuItem.Name = "manageDtainedToolStripMenuItem";
            this.manageDtainedToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.manageDtainedToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDtainedToolStripMenuItem.Click += new System.EventHandler(this.manageDtainedToolStripMenuItem_Click);
            // 
            // detainedLicenseToolStripMenuItem
            // 
            this.detainedLicenseToolStripMenuItem.Name = "detainedLicenseToolStripMenuItem";
            this.detainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.detainedLicenseToolStripMenuItem.Text = "Detained License";
            this.detainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainedLicenseToolStripMenuItem_Click);
            // 
            // relaseDetainedLicenseToolStripMenuItem
            // 
            this.relaseDetainedLicenseToolStripMenuItem.Name = "relaseDetainedLicenseToolStripMenuItem";
            this.relaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.relaseDetainedLicenseToolStripMenuItem.Text = "Relase Detained License";
            this.relaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.relaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // peopleManagementToolStripMenuItem
            // 
            this.peopleManagementToolStripMenuItem.Image = global::DVLManagementSystem.Properties.Resources.people_50px;
            this.peopleManagementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleManagementToolStripMenuItem.Name = "peopleManagementToolStripMenuItem";
            this.peopleManagementToolStripMenuItem.Size = new System.Drawing.Size(214, 56);
            this.peopleManagementToolStripMenuItem.Text = "People Management";
            this.peopleManagementToolStripMenuItem.Click += new System.EventHandler(this.peopleManagementToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLManagementSystem.Properties.Resources.Drivers_50px;
            this.driversToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(122, 56);
            this.driversToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::DVLManagementSystem.Properties.Resources.user_folder_50px;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(111, 56);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changeToolStripMenuItem,
            this.siToolStripMenuItem});
            this.accountSettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("accountSettingsToolStripMenuItem.Image")));
            this.accountSettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(188, 56);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentUserInfoToolStripMenuItem.Image")));
            this.currentUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(217, 36);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeToolStripMenuItem.Image")));
            this.changeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(217, 36);
            this.changeToolStripMenuItem.Text = "Change _Password";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // siToolStripMenuItem
            // 
            this.siToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("siToolStripMenuItem.Image")));
            this.siToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.siToolStripMenuItem.Name = "siToolStripMenuItem";
            this.siToolStripMenuItem.Size = new System.Drawing.Size(217, 36);
            this.siToolStripMenuItem.Text = "Sign Out";
            this.siToolStripMenuItem.Click += new System.EventHandler(this.siToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 642);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsLicennesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostOrDamagedLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenesApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenesApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDtainedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaseDetainedLicenseToolStripMenuItem;
    }
}

