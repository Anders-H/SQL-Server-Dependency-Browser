using System.Windows.Forms;

namespace Sql2022DependencyBrowser
{
    public class MessageDisplayer: IMessageDisplayer
    {
        public void Void(string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.None);

        public void Fail(string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Tell(string text, string title) =>
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}