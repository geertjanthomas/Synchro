namespace LocalDeploy.Forms
{
    partial class Start
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
            CRDW = new Button();
            Dashboard = new Button();
            StaticDataDepot = new Button();
            Kill = new Button();
            LaunchDashboard = new Button();
            LoadSDD = new Button();
            button1 = new Button();
            LRDW = new Button();
            SuspendLayout();
            // 
            // CRDW
            // 
            CRDW.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CRDW.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            CRDW.Location = new Point(12, 140);
            CRDW.Name = "CRDW";
            CRDW.Size = new Size(326, 58);
            CRDW.TabIndex = 2;
            CRDW.Text = "CRDW";
            CRDW.UseVisualStyleBackColor = true;
            CRDW.Click += CRDW_Click;
            // 
            // Dashboard
            // 
            Dashboard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Dashboard.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            Dashboard.Location = new Point(12, 268);
            Dashboard.Name = "Dashboard";
            Dashboard.Size = new Size(326, 58);
            Dashboard.TabIndex = 4;
            Dashboard.Text = "Dashboard";
            Dashboard.UseVisualStyleBackColor = true;
            Dashboard.Click += Dashboard_Click;
            // 
            // StaticDataDepot
            // 
            StaticDataDepot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StaticDataDepot.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            StaticDataDepot.Location = new Point(12, 204);
            StaticDataDepot.Name = "StaticDataDepot";
            StaticDataDepot.Size = new Size(326, 58);
            StaticDataDepot.TabIndex = 3;
            StaticDataDepot.Text = "Static Data Depot";
            StaticDataDepot.UseVisualStyleBackColor = true;
            StaticDataDepot.Click += StaticDataDepot_Click;
            // 
            // Kill
            // 
            Kill.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Kill.BackgroundImageLayout = ImageLayout.Stretch;
            Kill.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            Kill.ForeColor = Color.Red;
            Kill.Image = Properties.Resources.skull_and_crossbones;
            Kill.ImageAlign = ContentAlignment.MiddleLeft;
            Kill.Location = new Point(15, 507);
            Kill.Name = "Kill";
            Kill.Size = new Size(326, 71);
            Kill.TabIndex = 7;
            Kill.Text = "Reset All";
            Kill.TextAlign = ContentAlignment.MiddleRight;
            Kill.UseVisualStyleBackColor = true;
            Kill.Click += Kill_Click;
            // 
            // LaunchDashboard
            // 
            LaunchDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LaunchDashboard.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LaunchDashboard.Image = Properties.Resources.rocket_55;
            LaunchDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            LaunchDashboard.Location = new Point(12, 332);
            LaunchDashboard.Name = "LaunchDashboard";
            LaunchDashboard.Size = new Size(326, 72);
            LaunchDashboard.TabIndex = 5;
            LaunchDashboard.Text = "Launch Dashboard";
            LaunchDashboard.TextAlign = ContentAlignment.MiddleRight;
            LaunchDashboard.UseVisualStyleBackColor = true;
            LaunchDashboard.Click += LaunchDashboard_Click;
            // 
            // LoadSDD
            // 
            LoadSDD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LoadSDD.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LoadSDD.Location = new Point(12, 410);
            LoadSDD.Name = "LoadSDD";
            LoadSDD.Size = new Size(326, 58);
            LoadSDD.TabIndex = 6;
            LoadSDD.Text = "Load SDD 🡆 RDW";
            LoadSDD.UseVisualStyleBackColor = true;
            LoadSDD.Click += LoadSDD_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(326, 58);
            button1.TabIndex = 0;
            button1.Text = "First time instructions";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LRDW
            // 
            LRDW.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LRDW.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            LRDW.Location = new Point(12, 76);
            LRDW.Name = "LRDW";
            LRDW.Size = new Size(326, 58);
            LRDW.TabIndex = 1;
            LRDW.Text = "LRDW";
            LRDW.UseVisualStyleBackColor = true;
            LRDW.Click += LRDW_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 590);
            Controls.Add(button1);
            Controls.Add(LoadSDD);
            Controls.Add(LaunchDashboard);
            Controls.Add(Kill);
            Controls.Add(StaticDataDepot);
            Controls.Add(Dashboard);
            Controls.Add(LRDW);
            Controls.Add(CRDW);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Start";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RDW Local Deployment";
            Load += Start_Load;
            KeyPress += Start_KeyPress;
            ResumeLayout(false);
        }

        #endregion

        private Button CRDW;
        private Button Dashboard;
        private Button StaticDataDepot;
        private Button Kill;
        private Button LaunchDashboard;
        private Button LoadSDD;
        private Button button1;
        private Button LRDW;
    }
}