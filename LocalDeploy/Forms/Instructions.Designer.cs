namespace LocalDeploy.Forms
{
    partial class Instructions
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
            webBrowser = new WebBrowser();
            SuspendLayout();
            // 
            // webBrowser1
            // 
            webBrowser.Dock = DockStyle.Fill;
            webBrowser.Location = new Point(0, 0);
            webBrowser.Name = "webBrowser1";
            webBrowser.Size = new Size(951, 747);
            webBrowser.TabIndex = 0;
            webBrowser.Url = new Uri("about:blank", UriKind.Absolute);
            // 
            // Instructions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 747);
            Controls.Add(webBrowser);
            Name = "Instructions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instructions";
            Load += Instructions_Load;
            ResumeLayout(false);
        }

        #endregion
        private WebBrowser webBrowser;
    }
}