namespace LocalDeploy.Forms
{
    partial class DashboardDeploymentDashboard
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
            tabControl1 = new TabControl();
            tabOptions = new TabPage();
            chkRun = new CheckBox();
            chkDownloadArtifacts = new CheckBox();
            DownloadOptions = new GroupBox();
            CustomBranch = new TextBox();
            optCustomBranch = new RadioButton();
            optMasterBuild = new RadioButton();
            chkDashboard = new CheckBox();
            tabVariables = new TabPage();
            ValueBox = new TextBox();
            Variables = new ListView();
            colName = new ColumnHeader();
            colValue = new ColumnHeader();
            ButtonPanel = new Panel();
            btnSaveOptions = new Button();
            Explanation = new Label();
            btnClose = new Button();
            btnStart = new Button();
            tabControl1.SuspendLayout();
            tabOptions.SuspendLayout();
            DownloadOptions.SuspendLayout();
            tabVariables.SuspendLayout();
            ButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabOptions);
            tabControl1.Controls.Add(tabVariables);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(596, 271);
            tabControl1.TabIndex = 0;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(chkRun);
            tabOptions.Controls.Add(chkDownloadArtifacts);
            tabOptions.Controls.Add(DownloadOptions);
            tabOptions.Controls.Add(chkDashboard);
            tabOptions.Location = new Point(4, 24);
            tabOptions.Margin = new Padding(4, 3, 4, 3);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(4, 3, 4, 3);
            tabOptions.Size = new Size(588, 243);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Deployment Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // chkRun
            // 
            chkRun.AutoSize = true;
            chkRun.Location = new Point(22, 184);
            chkRun.Margin = new Padding(4, 3, 4, 3);
            chkRun.Name = "chkRun";
            chkRun.Size = new Size(126, 19);
            chkRun.TabIndex = 16;
            chkRun.Tag = "Run";
            chkRun.Text = "Run the dashboard";
            chkRun.UseVisualStyleBackColor = true;
            // 
            // chkDownloadArtifacts
            // 
            chkDownloadArtifacts.AutoSize = true;
            chkDownloadArtifacts.Location = new Point(15, 5);
            chkDownloadArtifacts.Margin = new Padding(4, 3, 4, 3);
            chkDownloadArtifacts.Name = "chkDownloadArtifacts";
            chkDownloadArtifacts.Size = new Size(125, 19);
            chkDownloadArtifacts.TabIndex = 0;
            chkDownloadArtifacts.Tag = "Download artifacts";
            chkDownloadArtifacts.Text = "Download artifacts";
            chkDownloadArtifacts.UseVisualStyleBackColor = true;
            chkDownloadArtifacts.CheckedChanged += chkDownloadArtifacts_CheckedChanged;
            // 
            // DownloadOptions
            // 
            DownloadOptions.Controls.Add(CustomBranch);
            DownloadOptions.Controls.Add(optCustomBranch);
            DownloadOptions.Controls.Add(optMasterBuild);
            DownloadOptions.Location = new Point(20, 7);
            DownloadOptions.Margin = new Padding(4, 3, 4, 3);
            DownloadOptions.Name = "DownloadOptions";
            DownloadOptions.Padding = new Padding(4, 3, 4, 3);
            DownloadOptions.Size = new Size(490, 109);
            DownloadOptions.TabIndex = 15;
            DownloadOptions.TabStop = false;
            // 
            // CustomBranch
            // 
            CustomBranch.Location = new Point(146, 55);
            CustomBranch.Margin = new Padding(4, 3, 4, 3);
            CustomBranch.Name = "CustomBranch";
            CustomBranch.Size = new Size(323, 23);
            CustomBranch.TabIndex = 15;
            // 
            // optCustomBranch
            // 
            optCustomBranch.AutoSize = true;
            optCustomBranch.Location = new Point(26, 55);
            optCustomBranch.Margin = new Padding(4, 3, 4, 3);
            optCustomBranch.Name = "optCustomBranch";
            optCustomBranch.Size = new Size(106, 19);
            optCustomBranch.TabIndex = 14;
            optCustomBranch.Text = "Custom release";
            optCustomBranch.UseVisualStyleBackColor = true;
            // 
            // optMasterBuild
            // 
            optMasterBuild.AutoSize = true;
            optMasterBuild.Checked = true;
            optMasterBuild.Location = new Point(26, 27);
            optMasterBuild.Margin = new Padding(4, 3, 4, 3);
            optMasterBuild.Name = "optMasterBuild";
            optMasterBuild.Size = new Size(143, 19);
            optMasterBuild.TabIndex = 13;
            optMasterBuild.TabStop = true;
            optMasterBuild.Text = "Latest build for master";
            optMasterBuild.UseVisualStyleBackColor = true;
            // 
            // chkDashboard
            // 
            chkDashboard.AutoSize = true;
            chkDashboard.Location = new Point(22, 145);
            chkDashboard.Margin = new Padding(4, 3, 4, 3);
            chkDashboard.Name = "chkDashboard";
            chkDashboard.Size = new Size(142, 19);
            chkDashboard.TabIndex = 8;
            chkDashboard.Tag = "Dashboard";
            chkDashboard.Text = "Deploy the dashboard";
            chkDashboard.UseVisualStyleBackColor = true;
            // 
            // tabVariables
            // 
            tabVariables.Controls.Add(ValueBox);
            tabVariables.Controls.Add(Variables);
            tabVariables.Location = new Point(4, 24);
            tabVariables.Margin = new Padding(4, 3, 4, 3);
            tabVariables.Name = "tabVariables";
            tabVariables.Padding = new Padding(4, 3, 4, 3);
            tabVariables.Size = new Size(588, 243);
            tabVariables.TabIndex = 1;
            tabVariables.Text = "Variables";
            tabVariables.UseVisualStyleBackColor = true;
            // 
            // ValueBox
            // 
            ValueBox.Location = new Point(10, 301);
            ValueBox.Margin = new Padding(4, 3, 4, 3);
            ValueBox.Name = "ValueBox";
            ValueBox.Size = new Size(116, 23);
            ValueBox.TabIndex = 1;
            ValueBox.Visible = false;
            ValueBox.TextChanged += ValueBox_TextChanged;
            ValueBox.KeyDown += ValueBox_KeyDown;
            ValueBox.Leave += ValueBox_Leave;
            // 
            // Variables
            // 
            Variables.Columns.AddRange(new ColumnHeader[] { colName, colValue });
            Variables.Dock = DockStyle.Fill;
            Variables.FullRowSelect = true;
            Variables.Location = new Point(4, 3);
            Variables.Margin = new Padding(4, 3, 4, 3);
            Variables.Name = "Variables";
            Variables.Size = new Size(580, 237);
            Variables.TabIndex = 2;
            Variables.UseCompatibleStateImageBehavior = false;
            Variables.View = View.Details;
            Variables.SelectedIndexChanged += Variables_SelectedIndexChanged;
            Variables.MouseClick += Variables_MouseClick;
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 300;
            // 
            // colValue
            // 
            colValue.Text = "Value";
            colValue.Width = 500;
            // 
            // ButtonPanel
            // 
            ButtonPanel.Controls.Add(btnSaveOptions);
            ButtonPanel.Controls.Add(Explanation);
            ButtonPanel.Controls.Add(btnClose);
            ButtonPanel.Controls.Add(btnStart);
            ButtonPanel.Dock = DockStyle.Bottom;
            ButtonPanel.Location = new Point(0, 271);
            ButtonPanel.Margin = new Padding(4, 3, 4, 3);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new Size(596, 148);
            ButtonPanel.TabIndex = 1;
            // 
            // btnSaveOptions
            // 
            btnSaveOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveOptions.DialogResult = DialogResult.Cancel;
            btnSaveOptions.Location = new Point(301, 104);
            btnSaveOptions.Margin = new Padding(4, 3, 4, 3);
            btnSaveOptions.Name = "btnSaveOptions";
            btnSaveOptions.Size = new Size(136, 27);
            btnSaveOptions.TabIndex = 13;
            btnSaveOptions.Text = "Save options only";
            btnSaveOptions.UseVisualStyleBackColor = true;
            btnSaveOptions.Click += btnSaveOptions_Click;
            // 
            // Explanation
            // 
            Explanation.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Explanation.ForeColor = Color.Maroon;
            Explanation.Location = new Point(19, 14);
            Explanation.Margin = new Padding(4, 0, 4, 0);
            Explanation.Name = "Explanation";
            Explanation.Size = new Size(495, 74);
            Explanation.TabIndex = 12;
            Explanation.Text = "Some explanation here";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(14, 104);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 27);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.DialogResult = DialogResult.Cancel;
            btnStart.Location = new Point(445, 104);
            btnStart.Margin = new Padding(4, 3, 4, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(136, 27);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start deployment";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // DashboardDeploymentDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(596, 419);
            Controls.Add(tabControl1);
            Controls.Add(ButtonPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DashboardDeploymentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard Deployment";
            Load += Form_Load;
            tabControl1.ResumeLayout(false);
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            DownloadOptions.ResumeLayout(false);
            DownloadOptions.PerformLayout();
            tabVariables.ResumeLayout(false);
            tabVariables.PerformLayout();
            ButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabVariables;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.CheckBox chkDownloadArtifacts;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkDashboard;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.ListView Variables;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label Explanation;
        private System.Windows.Forms.GroupBox DownloadOptions;
        private System.Windows.Forms.RadioButton optCustomBranch;
        private System.Windows.Forms.RadioButton optMasterBuild;
        private System.Windows.Forms.TextBox CustomBranch;
        private System.Windows.Forms.Button btnSaveOptions;
        private CheckBox chkRun;
    }
}