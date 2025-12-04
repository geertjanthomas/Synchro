namespace LocalDeploy.Forms
{
    partial class ResetWarning
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
            OK = new Button();
            Cancel = new Button();
            Warning = new Label();
            WarningHeader = new Label();
            SuspendLayout();
            // 
            // OK
            // 
            OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OK.BackColor = Color.Red;
            OK.DialogResult = DialogResult.OK;
            OK.FlatStyle = FlatStyle.Flat;
            OK.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            OK.ForeColor = Color.White;
            OK.Location = new Point(12, 404);
            OK.Name = "OK";
            OK.Size = new Size(153, 45);
            OK.TabIndex = 0;
            OK.Text = "OK";
            OK.UseVisualStyleBackColor = false;
            // 
            // Cancel
            // 
            Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cancel.BackColor = Color.FromArgb(0, 192, 0);
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Cancel.ForeColor = Color.White;
            Cancel.Location = new Point(516, 404);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(153, 45);
            Cancel.TabIndex = 1;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = false;
            // 
            // Warning
            // 
            Warning.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Warning.Font = new Font("Segoe UI", 14F);
            Warning.Location = new Point(12, 52);
            Warning.Name = "Warning";
            Warning.Size = new Size(657, 338);
            Warning.TabIndex = 2;
            Warning.Text = "label1";
            // 
            // WarningHeader
            // 
            WarningHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WarningHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            WarningHeader.Location = new Point(12, 9);
            WarningHeader.Name = "WarningHeader";
            WarningHeader.Size = new Size(657, 43);
            WarningHeader.TabIndex = 3;
            WarningHeader.Text = "WARNING!";
            WarningHeader.TextAlign = ContentAlignment.TopCenter;
            // 
            // ResetWarning
            // 
            AcceptButton = OK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new Size(681, 461);
            ControlBox = false;
            Controls.Add(WarningHeader);
            Controls.Add(Warning);
            Controls.Add(Cancel);
            Controls.Add(OK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetWarning";
            StartPosition = FormStartPosition.CenterScreen;
            Load += ResetWarning_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button OK;
        private Button Cancel;
        private Label Warning;
        private Label WarningHeader;
    }
}