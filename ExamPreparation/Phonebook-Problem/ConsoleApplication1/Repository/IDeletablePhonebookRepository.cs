namespace Phonebook.Repository
{
    public interface IDeletablePhonebookRepository : IPhonebookRepository
    {
        bool Remove(string phoneNumber);
    }
}