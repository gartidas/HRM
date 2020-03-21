namespace Desktop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.subMenuPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.personalMenuButton = new System.Windows.Forms.Button();
            this.workPlaceMenuButton = new System.Windows.Forms.Button();
            this.staffMenuButton = new System.Windows.Forms.Button();
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.minimizeButton = new System.Windows.Forms.Button();
            this.loginPictureBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1600, 60);
            this.topPanel.TabIndex = 0;
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(754, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "HRM";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.DimGray;
            this.mainPanel.Location = new System.Drawing.Point(400, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1200, 840);
            this.mainPanel.TabIndex = 1;
            // 
            // subMenuPanel
            // 
            this.subMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.subMenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.subMenuPanel.Location = new System.Drawing.Point(200, 60);
            this.subMenuPanel.Name = "subMenuPanel";
            this.subMenuPanel.Size = new System.Drawing.Size(200, 840);
            this.subMenuPanel.TabIndex = 3;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.timeLabel);
            this.menuPanel.Controls.Add(this.logOutButton);
            this.menuPanel.Controls.Add(this.personalMenuButton);
            this.menuPanel.Controls.Add(this.workPlaceMenuButton);
            this.menuPanel.Controls.Add(this.staffMenuButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 60);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 840);
            this.menuPanel.TabIndex = 2;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(7, 756);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(41, 20);
            this.timeLabel.TabIndex = 11;
            this.timeLabel.Text = "time";
            this.timeLabel.Visible = false;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.White;
            this.logOutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logOutButton.BackgroundImage")));
            this.logOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logOutButton.ForeColor = System.Drawing.Color.White;
            this.logOutButton.Location = new System.Drawing.Point(-1, 779);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(200, 60);
            this.logOutButton.TabIndex = 10;
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // personalMenuButton
            // 
            this.personalMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.personalMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("personalMenuButton.BackgroundImage")));
            this.personalMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.personalMenuButton.Location = new System.Drawing.Point(-1, 131);
            this.personalMenuButton.Name = "personalMenuButton";
            this.personalMenuButton.Size = new System.Drawing.Size(200, 60);
            this.personalMenuButton.TabIndex = 2;
            this.personalMenuButton.UseVisualStyleBackColor = false;
            this.personalMenuButton.Click += new System.EventHandler(this.personalMenuButton_Click);
            // 
            // workPlaceMenuButton
            // 
            this.workPlaceMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.workPlaceMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("workPlaceMenuButton.BackgroundImage")));
            this.workPlaceMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.workPlaceMenuButton.Location = new System.Drawing.Point(-1, 65);
            this.workPlaceMenuButton.Name = "workPlaceMenuButton";
            this.workPlaceMenuButton.Size = new System.Drawing.Size(200, 60);
            this.workPlaceMenuButton.TabIndex = 1;
            this.workPlaceMenuButton.UseVisualStyleBackColor = false;
            this.workPlaceMenuButton.Click += new System.EventHandler(this.workPlaceMenuButton_Click);
            // 
            // staffMenuButton
            // 
            this.staffMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.staffMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("staffMenuButton.BackgroundImage")));
            this.staffMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.staffMenuButton.Location = new System.Drawing.Point(-1, -1);
            this.staffMenuButton.Name = "staffMenuButton";
            this.staffMenuButton.Size = new System.Drawing.Size(200, 60);
            this.staffMenuButton.TabIndex = 0;
            this.staffMenuButton.UseVisualStyleBackColor = false;
            this.staffMenuButton.Click += new System.EventHandler(this.staffMenuButton_Click);
            // 
            // timeTimer
            // 
            this.timeTimer.Interval = 1000;
            this.timeTimer.Tick += new System.EventHandler(this.timeTimer_Tick);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(1462, 6);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(50, 50);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // loginPictureBox
            // 
            this.loginPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loginPictureBox.Image")));
            this.loginPictureBox.Location = new System.Drawing.Point(12, 9);
            this.loginPictureBox.Name = "loginPictureBox";
            this.loginPictureBox.Size = new System.Drawing.Size(52, 46);
            this.loginPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginPictureBox.TabIndex = 9;
            this.loginPictureBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = global::Desktop.Properties.Resources.Close;
            this.closeButton.Location = new System.Drawing.Point(1528, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 50);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.subMenuPanel);
            this.Controls.Add(this.loginPictureBox);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox loginPictureBox;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button personalMenuButton;
        private System.Windows.Forms.Button workPlaceMenuButton;
        private System.Windows.Forms.Button staffMenuButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer timeTimer;
        public System.Windows.Forms.Panel subMenuPanel;
    }
}