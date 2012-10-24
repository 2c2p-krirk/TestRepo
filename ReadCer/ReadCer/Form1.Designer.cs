namespace ReadCer
{
    partial class Form1
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCertLocation = new System.Windows.Forms.TextBox();
            this.txtCertPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnGetIPAddress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 113);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(909, 373);
            this.txtLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cert location:";
            // 
            // txtCertLocation
            // 
            this.txtCertLocation.Location = new System.Drawing.Point(123, 6);
            this.txtCertLocation.Name = "txtCertLocation";
            this.txtCertLocation.Size = new System.Drawing.Size(495, 20);
            this.txtCertLocation.TabIndex = 3;
            this.txtCertLocation.Text = "D:\\Service\\SinaptIQ.SSLPost\\MPI_Client_certificate(kbankmpi).pfx";
            // 
            // txtCertPassword
            // 
            this.txtCertPassword.Location = new System.Drawing.Point(123, 32);
            this.txtCertPassword.Name = "txtCertPassword";
            this.txtCertPassword.Size = new System.Drawing.Size(495, 20);
            this.txtCertPassword.TabIndex = 4;
            this.txtCertPassword.Text = "kbankmpi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Read Cer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(123, 58);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(495, 20);
            this.txtURL.TabIndex = 8;
            this.txtURL.Text = "https://directory.securecode.com";
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(819, 43);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(102, 24);
            this.btnPost.TabIndex = 9;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(819, 73);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(102, 24);
            this.btnClearLog.TabIndex = 10;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnGetIPAddress
            // 
            this.btnGetIPAddress.Location = new System.Drawing.Point(624, 58);
            this.btnGetIPAddress.Name = "btnGetIPAddress";
            this.btnGetIPAddress.Size = new System.Drawing.Size(102, 24);
            this.btnGetIPAddress.TabIndex = 11;
            this.btnGetIPAddress.Text = "Get IPAddress";
            this.btnGetIPAddress.UseVisualStyleBackColor = true;
            this.btnGetIPAddress.Click += new System.EventHandler(this.btnGetIPAddress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 511);
            this.Controls.Add(this.btnGetIPAddress);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCertPassword);
            this.Controls.Add(this.txtCertLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "Read Cer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCertLocation;
        private System.Windows.Forms.TextBox txtCertPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnGetIPAddress;
    }
}

