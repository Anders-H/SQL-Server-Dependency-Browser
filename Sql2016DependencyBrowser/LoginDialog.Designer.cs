namespace Sql2016DependencyBrowser
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
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 12);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(41, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Server:";
         // 
         // txtServer
         // 
         this.txtServer.Location = new System.Drawing.Point(12, 28);
         this.txtServer.MaxLength = 200;
         this.txtServer.Name = "txtServer";
         this.txtServer.Size = new System.Drawing.Size(268, 20);
         this.txtServer.TabIndex = 1;
         // 
         // radioIntegrated
         // 
         this.radioIntegrated.AutoSize = true;
         this.radioIntegrated.Checked = true;
         this.radioIntegrated.Location = new System.Drawing.Point(12, 56);
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
         this.radioSQLSecurity.Location = new System.Drawing.Point(12, 80);
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
         this.txtUsername.Location = new System.Drawing.Point(12, 120);
         this.txtUsername.MaxLength = 200;
         this.txtUsername.Name = "txtUsername";
         this.txtUsername.Size = new System.Drawing.Size(268, 20);
         this.txtUsername.TabIndex = 5;
         // 
         // lblUsername
         // 
         this.lblUsername.AutoSize = true;
         this.lblUsername.Enabled = false;
         this.lblUsername.Location = new System.Drawing.Point(12, 104);
         this.lblUsername.Name = "lblUsername";
         this.lblUsername.Size = new System.Drawing.Size(58, 13);
         this.lblUsername.TabIndex = 4;
         this.lblUsername.Text = "Username:";
         // 
         // txtPassword
         // 
         this.txtPassword.Enabled = false;
         this.txtPassword.Location = new System.Drawing.Point(12, 160);
         this.txtPassword.MaxLength = 200;
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(268, 20);
         this.txtPassword.TabIndex = 7;
         this.txtPassword.UseSystemPasswordChar = true;
         // 
         // lblPassword
         // 
         this.lblPassword.AutoSize = true;
         this.lblPassword.Enabled = false;
         this.lblPassword.Location = new System.Drawing.Point(12, 144);
         this.lblPassword.Name = "lblPassword";
         this.lblPassword.Size = new System.Drawing.Size(56, 13);
         this.lblPassword.TabIndex = 6;
         this.lblPassword.Text = "Password:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 184);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(56, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Database:";
         // 
         // cboDatabase
         // 
         this.cboDatabase.FormattingEnabled = true;
         this.cboDatabase.Location = new System.Drawing.Point(12, 204);
         this.cboDatabase.MaxLength = 200;
         this.cboDatabase.Name = "cboDatabase";
         this.cboDatabase.Size = new System.Drawing.Size(268, 21);
         this.cboDatabase.TabIndex = 9;
         this.cboDatabase.DropDown += new System.EventHandler(this.cboDatabase_DropDown);
         // 
         // btnTest
         // 
         this.btnTest.Location = new System.Drawing.Point(12, 252);
         this.btnTest.Name = "btnTest";
         this.btnTest.Size = new System.Drawing.Size(75, 23);
         this.btnTest.TabIndex = 10;
         this.btnTest.Text = "Test...";
         this.btnTest.UseVisualStyleBackColor = true;
         this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(124, 252);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 11;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(204, 252);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 12;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // LoginDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(290, 286);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.cboDatabase);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.lblPassword);
         this.Controls.Add(this.txtUsername);
         this.Controls.Add(this.lblUsername);
         this.Controls.Add(this.radioSQLSecurity);
         this.Controls.Add(this.radioIntegrated);
         this.Controls.Add(this.txtServer);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoginDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Login";
         this.Load += new System.EventHandler(this.LoginDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

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
   }
}