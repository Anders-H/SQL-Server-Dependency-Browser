using System;
using System.Windows.Forms;

namespace Sql2022DependencyBrowser
{
    public partial class LoginDialog : Form
    {
        public string ConnectionString { get; private set; }
        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }

        public LoginDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IWin32Window owner, string connectionString)
        {
            ConnectionString = connectionString;
            return ShowDialog(owner);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            txtServer.Text = txtServer.Text.Trim();
            cboDatabase.Text = cboDatabase.Text.Trim();

            if (txtServer.Text == "")
            {
                MessageBox.Show(@"Unknown server.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cboDatabase.Text == "")
                {
                    MessageBox.Show(@"Unknown database.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var cnstrBuild = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
                    {
                        DataSource = txtServer.Text,
                        InitialCatalog = cboDatabase.Text
                    };

                    if (radioIntegrated.Checked)
                    {
                        cnstrBuild.IntegratedSecurity = true;
                    }
                    else
                    {
                        if (txtUsername.Text == "" || txtPassword.Text == "")
                        {
                            MessageBox.Show(this, @"Missing username or password.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cnstrBuild.IntegratedSecurity = false;
                        cnstrBuild.UserID = txtUsername.Text;
                        cnstrBuild.Password = txtPassword.Text;
                    }

                    Cursor = Cursors.WaitCursor;
                    btnTest.Enabled = false;
                    Refresh();
                    var success = SqlHelper.TestConnection(cnstrBuild.ConnectionString);
                    btnTest.Enabled = true;
                    Cursor = Cursors.Default;

                    if (success)
                    {
                        if (SqlHelper.CheckVersion(cnstrBuild.ConnectionString))
                            MessageBox.Show(this, @"Test successful.", @"Test completed", MessageBoxButtons.OK, MessageBoxIcon.None);
                        else
                            MessageBox.Show(this, @"Not expected SQL Server version or insufficient permissions.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show(this, @"Can't connect to database.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void radioIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            lblUsername.Enabled = radioSQLSecurity.Checked;
            txtUsername.Enabled = radioSQLSecurity.Checked;
            lblPassword.Enabled = radioSQLSecurity.Checked;
            txtPassword.Enabled = radioSQLSecurity.Checked;
        }

        private void radioSQLSecurity_CheckedChanged(object sender, EventArgs e)
        {
            lblUsername.Enabled = radioSQLSecurity.Checked;
            txtUsername.Enabled = radioSQLSecurity.Checked;
            lblPassword.Enabled = radioSQLSecurity.Checked;
            txtPassword.Enabled = radioSQLSecurity.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var cnstrBuild = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
                {
                    DataSource = txtServer.Text,
                    InitialCatalog = cboDatabase.Text
                };

                if (radioIntegrated.Checked)
                {
                    cnstrBuild.IntegratedSecurity = true;
                }
                else
                {
                    cnstrBuild.IntegratedSecurity = false;
                    cnstrBuild.UserID = txtUsername.Text;
                    cnstrBuild.Password = txtPassword.Text;
                }

                Cursor = Cursors.WaitCursor;
                btnOK.Enabled = false;
                Refresh();
                var success = SqlHelper.TestConnection(cnstrBuild.ConnectionString);
                btnOK.Enabled = true;
                Cursor = Cursors.Default;
                
                if (success)
                {
                    ConnectionString = cnstrBuild.ConnectionString;
                    ServerName = cnstrBuild.DataSource;
                    DatabaseName = cnstrBuild.InitialCatalog;

                    if (Application.UserAppDataRegistry != null)
                        SaveForm();

                    DialogResult = DialogResult.OK;
                    return;
                }

                MessageBox.Show(this, @"The given information could not be used to connect to SQL Server.", @"Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show(this, @"The given information could not be used to connect to SQL Server.", @"Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveForm()
        {
            var securityType = "";

            if (radioIntegrated.Checked)
                securityType = "Integrated";
            else if (radioSQLSecurity.Checked)
                securityType = "SQL";

            if (Application.UserAppDataRegistry == null)
            {
                
            }
            else
            {
                Application.UserAppDataRegistry.SetValue("ServerName", txtServer.Text);
                Application.UserAppDataRegistry.SetValue("SecurityType", securityType);
                Application.UserAppDataRegistry.SetValue("Database", cboDatabase.Text);
                Application.UserAppDataRegistry.SetValue("Username", txtUsername.Text);
                Application.UserAppDataRegistry.SetValue("RememberPass", chkRememberPassword.Checked ? "Yes" : "No");
                Application.UserAppDataRegistry.SetValue("Pass", chkRememberPassword.Checked ? txtPassword.Text : "");
                Application.UserAppDataRegistry.SetValue("DesieredConnectionString", txtConStr.Text);
            }
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            if (Application.UserAppDataRegistry == null)
                return;

            txtServer.Text = Application.UserAppDataRegistry.GetValue("ServerName", "") as string ?? "";
            var securityType = Application.UserAppDataRegistry.GetValue("SecurityType", "") as string ?? "";

            switch (securityType)
            {
                case "Integrated":
                    radioIntegrated.Checked = true;
                    break;
                case "SQL":
                    radioSQLSecurity.Checked = true;
                    break;
            }

            cboDatabase.Text = Application.UserAppDataRegistry.GetValue("Database", "") as string ?? "";
            txtUsername.Text = Application.UserAppDataRegistry.GetValue("Username", "") as string ?? "";
            chkRememberPassword.Checked = (Application.UserAppDataRegistry.GetValue("RememberPass", "") as string ?? "") == "Yes";
            txtPassword.Text = Application.UserAppDataRegistry.GetValue("Pass", "") as string ?? "";
            txtConStr.Text = Application.UserAppDataRegistry.GetValue("DesieredConnectionString", "") as string ?? "";
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            cboDatabase.Items.Clear();
            Cursor = Cursors.WaitCursor;

            try
            {
                var cnstrBuild = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString) { DataSource = txtServer.Text, InitialCatalog = "master" };

                if (radioIntegrated.Checked)
                {
                    cnstrBuild.IntegratedSecurity = true;
                }
                else
                {
                    cnstrBuild.IntegratedSecurity = false;
                    cnstrBuild.UserID = txtUsername.Text;
                    cnstrBuild.Password = txtPassword.Text;
                }

                using (var cn = new System.Data.SqlClient.SqlConnection(cnstrBuild.ConnectionString))
                {
                    cn.Open();

                    using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT name FROM master..sysdatabases WHERE NOT name = 'master'", cn))
                    {
                        var r = cmd.ExecuteReader();

                        while (r.Read())
                        {
                            var s = r.IsDBNull(0) ? "" : r.GetString(0);
                            if (!string.IsNullOrEmpty(s))
                                cboDatabase.Items.Add(s);
                        }

                        r.Close();
                    }

                    cn.Close();
                }
            }
            catch
            {
                // ignored
            }

            Cursor = Cursors.Default;
        }
    }
}