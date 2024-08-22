using System.Windows.Forms;

namespace Sql2022DependencyBrowser
{
    public class MessageDisplayer: IMessageDisplayer
    {
        public void Void(IWin32Window owner, string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.None);

        public void Fail(IWin32Window owner, string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Tell(IWin32Window owner, string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}