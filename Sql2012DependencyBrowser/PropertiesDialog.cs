using System;
using System.Windows.Forms;

namespace Sql2012DependencyBrowser
{
    public partial class PropertiesDialog : Form
    {
        private DbObject DbObject { get; set; }
        private string ConnectionString { get; set; }
        private bool MoveAway { get; set; }
        public PropertiesDialog()
        {
            InitializeComponent();
        }
        internal DialogResult ShowDialog(IWin32Window owner, DbObject d, string connectionString, bool moveAway = false)
        {
            DbObject = d;
            ConnectionString = connectionString;
            MoveAway = moveAway;
            return ShowDialog(owner);
        }
        private void PropertiesDialog_Shown(object sender, EventArgs e)
        {
            txtObjectID.Text = DbObject.Id.ToString();
            txtType.Text = DbObject.Type;
            txtName.Text = DbObject.Name;
            Refresh();
            Cursor = Cursors.WaitCursor;
            try
            {
                using (var cn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cn.Open();
                    var sys = SysObject.GetObject(cn, DbObject.Id, DbObject.Type);
                    if (sys.SchemaId > 0 && !(string.IsNullOrEmpty(sys.SchemaName)))
                        txtSchema.Text = $@"{sys.SchemaName} (ID {sys.SchemaId})";
                    else if (sys.SchemaId > 0)
                        txtSchema.Text = $@"ID {sys.SchemaId}";
                    else if (!(string.IsNullOrEmpty(sys.SchemaName)))
                        txtSchema.Text = sys.SchemaName;
                    var deps = sys.GetDependencies(cn);
                    foreach (var o in deps)
                        listBox1.Items.Add(o);
                    txtSource.Text = sys.GetSource(cn);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                txtObjectID.Text += $@" (Warning: {ex.Message})";
            }
            Cursor = Cursors.Default;
        }
        private void PropertiesDialog_Load(object sender, EventArgs e)
        {
            if (!MoveAway)
                return;
            Top += 10;
            Left += 10;
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = listBox1.IndexFromPoint(e.X, e.Y);
            if (index == ListBox.NoMatches)
                return;
            if (index < 0 || index >= listBox1.Items.Count)
                return;
            var item = listBox1.Items[index] as DbObject;
            if (item == null)
                return;
            using (var x = new PropertiesDialog())
                x.ShowDialog(this, item, ConnectionString, true);
        }
    }
}
