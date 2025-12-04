namespace LocalDeploy.Forms
{
    partial class StaticDataDepotDeploymentDashboard
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
            chkLrdwReferenceDataLoad = new CheckBox();
            chkRdwLoad = new CheckBox();
            chkCprLoad = new CheckBox();
            chkRdwConfigurationload = new CheckBox();
            chkLeaLoad = new CheckBox();
            chkBfgLoad = new CheckBox();
            chkLrdwReferenceDataModel = new CheckBox();
            chkRdw = new CheckBox();
            chkCprModel = new CheckBox();
            chkRdwConfigurationModel = new CheckBox();
            chkLeaModel = new CheckBox();
            chkBfgModel = new CheckBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chkDownloadArtifacts = new CheckBox();
            DownloadOptions = new GroupBox();
            CustomBranch = new TextBox();
            optCustomBranch = new RadioButton();
            optMain = new RadioButton();
            chkDatabase = new CheckBox();
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
            tabControl1.Size = new Size(599, 379);
            tabControl1.TabIndex = 0;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(chkLrdwReferenceDataLoad);
            tabOptions.Controls.Add(chkRdwLoad);
            tabOptions.Controls.Add(chkCprLoad);
            tabOptions.Controls.Add(chkRdwConfigurationload);
            tabOptions.Controls.Add(chkLeaLoad);
            tabOptions.Controls.Add(chkBfgLoad);
            tabOptions.Controls.Add(chkLrdwReferenceDataModel);
            tabOptions.Controls.Add(chkRdw);
            tabOptions.Controls.Add(chkCprModel);
            tabOptions.Controls.Add(chkRdwConfigurationModel);
            tabOptions.Controls.Add(chkLeaModel);
            tabOptions.Controls.Add(chkBfgModel);
            tabOptions.Controls.Add(label8);
            tabOptions.Controls.Add(label7);
            tabOptions.Controls.Add(label6);
            tabOptions.Controls.Add(label5);
            tabOptions.Controls.Add(label4);
            tabOptions.Controls.Add(label3);
            tabOptions.Controls.Add(label2);
            tabOptions.Controls.Add(label1);
            tabOptions.Controls.Add(chkDownloadArtifacts);
            tabOptions.Controls.Add(DownloadOptions);
            tabOptions.Controls.Add(chkDatabase);
            tabOptions.Location = new Point(4, 24);
            tabOptions.Margin = new Padding(4, 3, 4, 3);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(4, 3, 4, 3);
            tabOptions.Size = new Size(591, 351);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Deployment Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // chkLrdwReferenceDataLoad
            // 
            chkLrdwReferenceDataLoad.AutoSize = true;
            chkLrdwReferenceDataLoad.Location = new Point(303, 297);
            chkLrdwReferenceDataLoad.Name = "chkLrdwReferenceDataLoad";
            chkLrdwReferenceDataLoad.Size = new Size(15, 14);
            chkLrdwReferenceDataLoad.TabIndex = 35;
            chkLrdwReferenceDataLoad.Tag = "LrdwReferenceDataLoad";
            chkLrdwReferenceDataLoad.UseVisualStyleBackColor = true;
            // 
            // chkRdwLoad
            // 
            chkRdwLoad.AutoSize = true;
            chkRdwLoad.Location = new Point(303, 271);
            chkRdwLoad.Name = "chkRdwLoad";
            chkRdwLoad.Size = new Size(15, 14);
            chkRdwLoad.TabIndex = 34;
            chkRdwLoad.Tag = "RdwLoad";
            chkRdwLoad.UseVisualStyleBackColor = true;
            // 
            // chkCprLoad
            // 
            chkCprLoad.AutoSize = true;
            chkCprLoad.Location = new Point(303, 219);
            chkCprLoad.Name = "chkCprLoad";
            chkCprLoad.Size = new Size(15, 14);
            chkCprLoad.TabIndex = 33;
            chkCprLoad.Tag = "CprLoad";
            chkCprLoad.UseVisualStyleBackColor = true;
            // 
            // chkRdwConfigurationload
            // 
            chkRdwConfigurationload.AutoSize = true;
            chkRdwConfigurationload.Location = new Point(303, 245);
            chkRdwConfigurationload.Name = "chkRdwConfigurationload";
            chkRdwConfigurationload.Size = new Size(15, 14);
            chkRdwConfigurationload.TabIndex = 32;
            chkRdwConfigurationload.Tag = "RdwConfigurationLoad";
            chkRdwConfigurationload.UseVisualStyleBackColor = true;
            // 
            // chkLeaLoad
            // 
            chkLeaLoad.AutoSize = true;
            chkLeaLoad.Location = new Point(303, 193);
            chkLeaLoad.Name = "chkLeaLoad";
            chkLeaLoad.Size = new Size(15, 14);
            chkLeaLoad.TabIndex = 31;
            chkLeaLoad.Tag = "LeaLoad";
            chkLeaLoad.UseVisualStyleBackColor = true;
            // 
            // chkBfgLoad
            // 
            chkBfgLoad.AutoSize = true;
            chkBfgLoad.Location = new Point(303, 167);
            chkBfgLoad.Name = "chkBfgLoad";
            chkBfgLoad.Size = new Size(15, 14);
            chkBfgLoad.TabIndex = 30;
            chkBfgLoad.Tag = "BfgLoad";
            chkBfgLoad.UseVisualStyleBackColor = true;
            // 
            // chkLrdwReferenceDataModel
            // 
            chkLrdwReferenceDataModel.AutoSize = true;
            chkLrdwReferenceDataModel.Location = new Point(194, 297);
            chkLrdwReferenceDataModel.Name = "chkLrdwReferenceDataModel";
            chkLrdwReferenceDataModel.Size = new Size(15, 14);
            chkLrdwReferenceDataModel.TabIndex = 29;
            chkLrdwReferenceDataModel.Tag = "LrdwReferenceDataModel";
            chkLrdwReferenceDataModel.UseVisualStyleBackColor = true;
            // 
            // chkRdw
            // 
            chkRdw.AutoSize = true;
            chkRdw.Location = new Point(194, 271);
            chkRdw.Name = "chkRdw";
            chkRdw.Size = new Size(15, 14);
            chkRdw.TabIndex = 28;
            chkRdw.Tag = "RdwModel";
            chkRdw.UseVisualStyleBackColor = true;
            // 
            // chkCprModel
            // 
            chkCprModel.AutoSize = true;
            chkCprModel.Location = new Point(194, 219);
            chkCprModel.Name = "chkCprModel";
            chkCprModel.Size = new Size(15, 14);
            chkCprModel.TabIndex = 27;
            chkCprModel.Tag = "CprModel";
            chkCprModel.UseVisualStyleBackColor = true;
            // 
            // chkRdwConfigurationModel
            // 
            chkRdwConfigurationModel.AutoSize = true;
            chkRdwConfigurationModel.Location = new Point(194, 245);
            chkRdwConfigurationModel.Name = "chkRdwConfigurationModel";
            chkRdwConfigurationModel.Size = new Size(15, 14);
            chkRdwConfigurationModel.TabIndex = 26;
            chkRdwConfigurationModel.Tag = "RdwConfigurationModel";
            chkRdwConfigurationModel.UseVisualStyleBackColor = true;
            // 
            // chkLeaModel
            // 
            chkLeaModel.AutoSize = true;
            chkLeaModel.Location = new Point(194, 193);
            chkLeaModel.Name = "chkLeaModel";
            chkLeaModel.Size = new Size(15, 14);
            chkLeaModel.TabIndex = 25;
            chkLeaModel.Tag = "LeaModel";
            chkLeaModel.UseVisualStyleBackColor = true;
            // 
            // chkBfgModel
            // 
            chkBfgModel.AutoSize = true;
            chkBfgModel.Location = new Point(194, 167);
            chkBfgModel.Name = "chkBfgModel";
            chkBfgModel.Size = new Size(15, 14);
            chkBfgModel.TabIndex = 24;
            chkBfgModel.Tag = "BfgModel";
            chkBfgModel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(34, 300);
            label8.Name = "label8";
            label8.Size = new Size(125, 15);
            label8.TabIndex = 23;
            label8.Text = "LRDW_Reference_Data";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 273);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 22;
            label7.Text = "RDW";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 246);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 21;
            label6.Text = "RDW_Configuration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 219);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 20;
            label5.Text = "CPR";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 192);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 19;
            label4.Text = "LEA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 165);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 18;
            label3.Text = "BFG";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 138);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 17;
            label2.Text = "Initial data load";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 138);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 16;
            label1.Text = "Model";
            // 
            // chkDownloadArtifacts
            // 
            chkDownloadArtifacts.AutoSize = true;
            chkDownloadArtifacts.Location = new Point(15, 5);
            chkDownloadArtifacts.Margin = new Padding(4, 3, 4, 3);
            chkDownloadArtifacts.Name = "chkDownloadArtifacts";
            chkDownloadArtifacts.Size = new Size(156, 19);
            chkDownloadArtifacts.TabIndex = 0;
            chkDownloadArtifacts.Tag = "Download artifacts";
            chkDownloadArtifacts.Text = "Download latest artifacts";
            chkDownloadArtifacts.UseVisualStyleBackColor = true;
            chkDownloadArtifacts.CheckedChanged += chkDownloadArtifacts_CheckedChanged;
            // 
            // DownloadOptions
            // 
            DownloadOptions.Controls.Add(CustomBranch);
            DownloadOptions.Controls.Add(optCustomBranch);
            DownloadOptions.Controls.Add(optMain);
            DownloadOptions.Location = new Point(20, 7);
            DownloadOptions.Margin = new Padding(4, 3, 4, 3);
            DownloadOptions.Name = "DownloadOptions";
            DownloadOptions.Padding = new Padding(4, 3, 4, 3);
            DownloadOptions.Size = new Size(490, 102);
            DownloadOptions.TabIndex = 15;
            DownloadOptions.TabStop = false;
            // 
            // CustomBranch
            // 
            CustomBranch.Location = new Point(146, 58);
            CustomBranch.Margin = new Padding(4, 3, 4, 3);
            CustomBranch.Name = "CustomBranch";
            CustomBranch.Size = new Size(323, 23);
            CustomBranch.TabIndex = 15;
            // 
            // optCustomBranch
            // 
            optCustomBranch.AutoSize = true;
            optCustomBranch.Location = new Point(26, 58);
            optCustomBranch.Margin = new Padding(4, 3, 4, 3);
            optCustomBranch.Name = "optCustomBranch";
            optCustomBranch.Size = new Size(107, 19);
            optCustomBranch.TabIndex = 14;
            optCustomBranch.Text = "Custom branch";
            optCustomBranch.UseVisualStyleBackColor = true;
            // 
            // optMain
            // 
            optMain.AutoSize = true;
            optMain.Checked = true;
            optMain.Location = new Point(26, 30);
            optMain.Margin = new Padding(4, 3, 4, 3);
            optMain.Name = "optMain";
            optMain.Size = new Size(92, 19);
            optMain.TabIndex = 13;
            optMain.TabStop = true;
            optMain.Text = "Main branch";
            optMain.UseVisualStyleBackColor = true;
            // 
            // chkDatabase
            // 
            chkDatabase.AutoSize = true;
            chkDatabase.Location = new Point(13, 115);
            chkDatabase.Margin = new Padding(4, 3, 4, 3);
            chkDatabase.Name = "chkDatabase";
            chkDatabase.Size = new Size(133, 19);
            chkDatabase.TabIndex = 8;
            chkDatabase.Tag = "Database";
            chkDatabase.Text = "Deploy the database";
            chkDatabase.UseVisualStyleBackColor = true;
            // 
            // tabVariables
            // 
            tabVariables.Controls.Add(ValueBox);
            tabVariables.Controls.Add(Variables);
            tabVariables.Location = new Point(4, 24);
            tabVariables.Margin = new Padding(4, 3, 4, 3);
            tabVariables.Name = "tabVariables";
            tabVariables.Padding = new Padding(4, 3, 4, 3);
            tabVariables.Size = new Size(591, 351);
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
            Variables.Size = new Size(583, 345);
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
            ButtonPanel.Location = new Point(0, 379);
            ButtonPanel.Margin = new Padding(4, 3, 4, 3);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new Size(599, 148);
            ButtonPanel.TabIndex = 1;
            // 
            // btnSaveOptions
            // 
            btnSaveOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveOptions.DialogResult = DialogResult.Cancel;
            btnSaveOptions.Location = new Point(158, 104);
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
            btnStart.Location = new Point(302, 104);
            btnStart.Margin = new Padding(4, 3, 4, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(136, 27);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start deployment";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // StaticDataDepotDeploymentDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(599, 527);
            Controls.Add(tabControl1);
            Controls.Add(ButtonPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "StaticDataDepotDeploymentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaticDataDepot Deployment";
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
        private System.Windows.Forms.CheckBox chkDatabase;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.ListView Variables;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label Explanation;
        private System.Windows.Forms.GroupBox DownloadOptions;
        private System.Windows.Forms.RadioButton optCustomBranch;
        private System.Windows.Forms.RadioButton optMain;
        private System.Windows.Forms.TextBox CustomBranch;
        private System.Windows.Forms.Button btnSaveOptions;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkLrdwReferenceDataLoad;
        private CheckBox chkRdwLoad;
        private CheckBox chkCprLoad;
        private CheckBox chkRdwConfigurationload;
        private CheckBox chkLeaLoad;
        private CheckBox chkBfgLoad;
        private CheckBox chkLrdwReferenceDataModel;
        private CheckBox chkRdw;
        private CheckBox chkCprModel;
        private CheckBox chkRdwConfigurationModel;
        private CheckBox chkLeaModel;
        private CheckBox chkBfgModel;
    }
}