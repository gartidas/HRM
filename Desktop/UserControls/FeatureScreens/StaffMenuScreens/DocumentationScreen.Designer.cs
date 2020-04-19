namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    partial class DocumentationScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentationScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.documentationListView = new System.Windows.Forms.ListView();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 41);
            this.label1.TabIndex = 21;
            this.label1.Text = "Documentation";
            // 
            // documentationListView
            // 
            this.documentationListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.documentationListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentationListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.documentationListView.ForeColor = System.Drawing.Color.White;
            this.documentationListView.FullRowSelect = true;
            this.documentationListView.GridLines = true;
            this.documentationListView.HideSelection = false;
            this.documentationListView.Location = new System.Drawing.Point(220, 101);
            this.documentationListView.MultiSelect = false;
            this.documentationListView.Name = "documentationListView";
            this.documentationListView.ShowItemToolTips = true;
            this.documentationListView.Size = new System.Drawing.Size(700, 418);
            this.documentationListView.TabIndex = 22;
            this.documentationListView.UseCompatibleStateImageBehavior = false;
            this.documentationListView.View = System.Windows.Forms.View.List;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.errorLabel);
            this.controlPanel.Controls.Add(this.deleteButton);
            this.controlPanel.Controls.Add(this.downloadButton);
            this.controlPanel.Controls.Add(this.uploadButton);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Location = new System.Drawing.Point(220, 538);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(700, 255);
            this.controlPanel.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(609, 39);
            this.label3.TabIndex = 28;
            this.label3.Text = "(size of a file can\'t be bigger than 2 GB)";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 53);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(88, 39);
            this.errorLabel.TabIndex = 24;
            this.errorLabel.Text = "error";
            this.errorLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteButton.Location = new System.Drawing.Point(480, 119);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(200, 60);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.downloadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("downloadButton.BackgroundImage")));
            this.downloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.downloadButton.Location = new System.Drawing.Point(250, 119);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(200, 60);
            this.downloadButton.TabIndex = 21;
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.uploadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uploadButton.BackgroundImage")));
            this.uploadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uploadButton.Location = new System.Drawing.Point(20, 119);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(200, 60);
            this.uploadButton.TabIndex = 20;
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 41);
            this.label2.TabIndex = 19;
            this.label2.Text = "Documentation control";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.ForeColor = System.Drawing.Color.White;
            this.emailLabel.Location = new System.Drawing.Point(220, 57);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(99, 39);
            this.emailLabel.TabIndex = 27;
            this.emailLabel.Text = "email";
            this.emailLabel.Visible = false;
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.doneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.doneButton.ForeColor = System.Drawing.Color.White;
            this.doneButton.Location = new System.Drawing.Point(936, 724);
            this.doneButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(200, 60);
            this.doneButton.TabIndex = 28;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // DocumentationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.documentationListView);
            this.Controls.Add(this.label1);
            this.Name = "DocumentationScreen";
            this.Size = new System.Drawing.Size(1156, 840);
            this.Load += new System.EventHandler(this.DocumentationScreen_Load);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView documentationListView;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button doneButton;
    }
}
