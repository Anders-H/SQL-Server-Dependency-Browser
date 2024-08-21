using System.Windows.Forms;

namespace Sql2022DependencyBrowser
{
    public class MainWindowController
    {
        private readonly TreeView _treeView;

        public MainWindowController(TreeView treeView)
        {
            _treeView = treeView;
        }

        public TreeNode AddRootFolder(string text, int icon)
        {
            var r = _treeView.Nodes.Add(text);
            r.ImageIndex = icon;
            r.SelectedImageIndex = icon;
            return r;
        }
    }
}