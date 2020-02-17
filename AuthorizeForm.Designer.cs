namespace OnSubmit.STunes
{
    partial class AuthorizeForm
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGetAccessToken = new System.Windows.Forms.Button();
            this.linkLabelClientId = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRedirectUri = new System.Windows.Forms.TextBox();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 152);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(453, 573);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.webBrowser, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxUrl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.6F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.4F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(459, 728);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(3, 126);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.ReadOnly = true;
            this.textBoxUrl.Size = new System.Drawing.Size(453, 20);
            this.textBoxUrl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonGetAccessToken);
            this.panel1.Controls.Add(this.linkLabelClientId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxRedirectUri);
            this.panel1.Controls.Add(this.textBoxClientSecret);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxClientId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 117);
            this.panel1.TabIndex = 2;
            // 
            // buttonGetAccessToken
            // 
            this.buttonGetAccessToken.Enabled = false;
            this.buttonGetAccessToken.Location = new System.Drawing.Point(85, 88);
            this.buttonGetAccessToken.Name = "buttonGetAccessToken";
            this.buttonGetAccessToken.Size = new System.Drawing.Size(75, 23);
            this.buttonGetAccessToken.TabIndex = 7;
            this.buttonGetAccessToken.Text = "Get Access Token";
            this.buttonGetAccessToken.UseVisualStyleBackColor = true;
            this.buttonGetAccessToken.Click += new System.EventHandler(this.buttonGetAccessToken_Click);
            // 
            // linkLabelClientId
            // 
            this.linkLabelClientId.AutoSize = true;
            this.linkLabelClientId.Location = new System.Drawing.Point(29, 12);
            this.linkLabelClientId.Name = "linkLabelClientId";
            this.linkLabelClientId.Size = new System.Drawing.Size(50, 13);
            this.linkLabelClientId.TabIndex = 6;
            this.linkLabelClientId.TabStop = true;
            this.linkLabelClientId.Text = "Client ID:";
            this.linkLabelClientId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClientId_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Redirect URI:";
            // 
            // textBoxRedirectUri
            // 
            this.textBoxRedirectUri.Location = new System.Drawing.Point(85, 61);
            this.textBoxRedirectUri.Name = "textBoxRedirectUri";
            this.textBoxRedirectUri.Size = new System.Drawing.Size(359, 20);
            this.textBoxRedirectUri.TabIndex = 4;
            this.textBoxRedirectUri.TextChanged += new System.EventHandler(this.textBoxRedirectUri_TextChanged);
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Location = new System.Drawing.Point(85, 35);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.PasswordChar = '•';
            this.textBoxClientSecret.Size = new System.Drawing.Size(359, 20);
            this.textBoxClientSecret.TabIndex = 3;
            this.textBoxClientSecret.TextChanged += new System.EventHandler(this.textBoxClientSecret_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client Secret:";
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Location = new System.Drawing.Point(85, 9);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(359, 20);
            this.textBoxClientId.TabIndex = 1;
            this.textBoxClientId.TextChanged += new System.EventHandler(this.textBoxClientId_TextChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(459, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar.Visible = false;
            // 
            // AuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 750);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.MinimizeBox = false;
            this.Name = "AuthorizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Retrieve access token";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabelClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRedirectUri;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Button buttonGetAccessToken;
    }
}