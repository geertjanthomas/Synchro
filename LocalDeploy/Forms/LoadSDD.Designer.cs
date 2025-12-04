namespace LocalDeploy.Forms
{
    partial class LoadSdd
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
            groupBox1 = new GroupBox();
            optLRDW = new RadioButton();
            optRDW = new RadioButton();
            optRDWConfig = new RadioButton();
            StartLoad = new Button();
            CloseForm = new Button();
            label1 = new Label();
            SqlServerInstance = new TextBox();
            Messages = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(optLRDW);
            groupBox1.Controls.Add(optRDW);
            groupBox1.Controls.Add(optRDWConfig);
            groupBox1.Location = new Point(12, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(195, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Models";
            // 
            // optLRDW
            // 
            optLRDW.AutoSize = true;
            optLRDW.Location = new Point(21, 101);
            optLRDW.Name = "optLRDW";
            optLRDW.Size = new Size(138, 19);
            optLRDW.TabIndex = 2;
            optLRDW.TabStop = true;
            optLRDW.Text = "LRDW Reference data";
            optLRDW.UseVisualStyleBackColor = true;
            optLRDW.Visible = false;
            // 
            // optRDW
            // 
            optRDW.AutoSize = true;
            optRDW.Location = new Point(21, 65);
            optRDW.Name = "optRDW";
            optRDW.Size = new Size(110, 19);
            optRDW.TabIndex = 1;
            optRDW.TabStop = true;
            optRDW.Text = "RDW Static Data";
            optRDW.UseVisualStyleBackColor = true;
            // 
            // optRDWConfig
            // 
            optRDWConfig.AutoSize = true;
            optRDWConfig.Location = new Point(21, 29);
            optRDWConfig.Name = "optRDWConfig";
            optRDWConfig.Size = new Size(128, 19);
            optRDWConfig.TabIndex = 0;
            optRDWConfig.TabStop = true;
            optRDWConfig.Text = "RDW Configuration";
            optRDWConfig.UseVisualStyleBackColor = true;
            // 
            // StartLoad
            // 
            StartLoad.Location = new Point(12, 224);
            StartLoad.Name = "StartLoad";
            StartLoad.Size = new Size(120, 23);
            StartLoad.TabIndex = 1;
            StartLoad.Text = "Start loading";
            StartLoad.UseVisualStyleBackColor = true;
            StartLoad.Click += StartLoad_Click;
            // 
            // CloseForm
            // 
            CloseForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseForm.Location = new Point(279, 224);
            CloseForm.Name = "CloseForm";
            CloseForm.Size = new Size(99, 23);
            CloseForm.TabIndex = 2;
            CloseForm.Text = "Close";
            CloseForm.UseVisualStyleBackColor = true;
            CloseForm.Click += CloseForm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 3;
            label1.Text = "SQL Server Instance";
            // 
            // SqlServerInstance
            // 
            SqlServerInstance.Location = new Point(12, 27);
            SqlServerInstance.Name = "SqlServerInstance";
            SqlServerInstance.Size = new Size(195, 23);
            SqlServerInstance.TabIndex = 4;
            SqlServerInstance.Text = ".\\VM_DEV_01";
            // 
            // Messages
            // 
            Messages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Messages.Location = new Point(12, 253);
            Messages.Multiline = true;
            Messages.Name = "Messages";
            Messages.ScrollBars = ScrollBars.Vertical;
            Messages.Size = new Size(366, 119);
            Messages.TabIndex = 5;
            // 
            // LoadSdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseForm;
            ClientSize = new Size(390, 384);
            Controls.Add(Messages);
            Controls.Add(SqlServerInstance);
            Controls.Add(label1);
            Controls.Add(CloseForm);
            Controls.Add(StartLoad);
            Controls.Add(groupBox1);
            Name = "LoadSdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadSDD";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton optLRDW;
        private RadioButton optRDW;
        private RadioButton optRDWConfig;
        private Button StartLoad;
        private Button CloseForm;
        private Label label1;
        private TextBox SqlServerInstance;
        private TextBox Messages;
    }
}