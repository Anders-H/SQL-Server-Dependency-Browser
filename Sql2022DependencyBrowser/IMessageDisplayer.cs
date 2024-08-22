using System.Windows.Forms;

namespace Sql2022DependencyBrowser
{
    public interface IMessageDisplayer
    {
        void Void(IWin32Window owner, string text, string title);
        void Fail(IWin32Window owner, string text, string title);
        void Tell(IWin32Window owner, string text, string title);
    }
}