namespace LocalDeploy.Forms
{
    partial class SelectObjectsForDeployment
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
            chkAll = new CheckBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Location = new Point(20, 25);
            chkAll.Margin = new Padding(4, 3, 4, 3);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(40, 19);
            chkAll.TabIndex = 13;
            chkAll.Text = "All";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOk.Location = new Point(33, 102);
            btnOk.Margin = new Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(88, 27);
            btnOk.TabIndex = 14;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(161, 102);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 27);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SelectObjectsForDeployment
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(523, 170);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(chkAll);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SelectObjectsForDeployment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Databases";
            Load += SelectDatabases_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}