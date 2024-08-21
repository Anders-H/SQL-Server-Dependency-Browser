namespace Sql2022DependencyBrowser
{
    public interface IMessageDisplayer
    {
        void Void(string text, string title);
        void Fail(string text, string title);
        void Tell(string text, string title);
    }
}