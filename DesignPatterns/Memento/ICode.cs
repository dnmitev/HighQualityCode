namespace Memento
{
    public interface ICode
    {
        string CodeAsText { get; }

        void Save(string code);
    }
}