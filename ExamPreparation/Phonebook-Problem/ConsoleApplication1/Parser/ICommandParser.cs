namespace Phonebook.Parser
{
    public interface ICommandParser
    {
        CommandInfo Parse(string text);
    }
}