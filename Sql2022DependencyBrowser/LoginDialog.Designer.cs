namespace Sql2022DependencyBrowser
{
   partial class LoginDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.radioIntegrated = new System.Windows.Forms.RadioButton();
            this.radioSQLSecurity = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.chkTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(8, 24);
            this.txtServer.MaxLength = 200;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(508, 20);
            this.txtServer.TabIndex = 1;
            // 
            // radioIntegrated
            // 
            this.radioIntegrated.AutoSize = true;
            this.radioIntegrated.Checked = true;
            this.radioIntegrated.Location = new System.Drawing.Point(8, 52);
            this.radioIntegrated.Name = "radioIntegrated";
            this.radioIntegrated.Size = new System.Drawing.Size(112, 17);
            this.radioIntegrated.TabIndex = 2;
            this.radioIntegrated.TabStop = true;
            this.radioIntegrated.Text = "Integrated security";
            this.radioIntegrated.UseVisualStyleBackColor = true;
            this.radioIntegrated.CheckedChanged += new System.EventHandler(this.radioIntegrated_CheckedChanged);
            // 
            // radioSQLSecurity
            // 
            this.radioSQLSecurity.AutoSize = true;
            this.radioSQLSecurity.Location = new System.Drawing.Point(132, 52);
            this.radioSQLSecurity.Name = "radioSQLSecurity";
            this.radioSQLSecurity.Size = new System.Drawing.Size(119, 17);
            this.radioSQLSecurity.TabIndex = 3;
            this.radioSQLSecurity.Text = "SQL Server security";
            this.radioSQLSecurity.UseVisualStyleBackColor = true;
            this.radioSQLSecurity.CheckedChanged += new System.EventHandler(this.radioSQLSecurity_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(8, 96);
            this.txtUsername.MaxLength = 200;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(508, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Enabled = false;
            this.lblUsername.Location = new System.Drawing.Point(8, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(8, 136);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(360, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Location = new System.Drawing.Point(8, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Database:";
            // 
            // cboDatabase
            // 
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(8, 176);
            this.cboDatabase.MaxLength = 200;
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(360, 21);
            this.cboDatabase.TabIndex = 10;
            this.cboDatabase.DropDown += new System.EventHandler(this.cboDatabase_DropDown);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 240);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test...";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(376, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(456, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(384, 136);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(125, 17);
            this.chkRememberPassword.TabIndex = 8;
            this.chkRememberPassword.Text = "Remember password";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 232);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkTrustServerCertificate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkRememberPassword);
            this.tabPage1.Controls.Add(this.txtServer);
            this.tabPage1.Controls.Add(this.radioIntegrated);
            this.tabPage1.Controls.Add(this.radioSQLSecurity);
            this.tabPage1.Controls.Add(this.lblUsername);
            this.tabPage1.Controls.Add(this.cboDatabase);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblPassword);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 206);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection properties";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtConStr);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 206);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Use a connection string";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Use this tab to ignore the properties and connect using a connection string.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connection string:";
            // 
            // txtConStr
            // 
            this.txtConStr.Location = new System.Drawing.Point(8, 176);
            this.txtConStr.MaxLength = 200;
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(508, 20);
            this.txtConStr.TabIndex = 2;
            // 
            // chkTrustServerCertificate
            // 
            this.chkTrustServerCertificate.AutoSize = true;
            this.chkTrustServerCertificate.Location = new System.Drawing.Point(384, 180);
            this.chkTrustServerCertificate.Name = "chkTrustServerCertificate";
            this.chkTrustServerCertificate.Size = new System.Drawing.Size(131, 17);
            this.chkTrustServerCertificate.TabIndex = 11;
            this.chkTrustServerCertificate.Text = "Trust server certificate";
            this.chkTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(539, 268);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtServer;
      private System.Windows.Forms.RadioButton radioIntegrated;
      private System.Windows.Forms.RadioButton radioSQLSecurity;
      private System.Windows.Forms.TextBox txtUsername;
      private System.Windows.Forms.Label lblUsername;
      private System.Windows.Forms.TextBox txtPassword;
      private System.Windows.Forms.Label lblPassword;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox cboDatabase;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.CheckBox chkTrustServerCertificate;
    }
}