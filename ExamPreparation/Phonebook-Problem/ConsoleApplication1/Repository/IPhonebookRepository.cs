namespace Phonebook.Repository
{
    using System.Collections.Generic;
    using Phonebook;

    public interface IPhonebookRepository
    {
        bool CanPhoneBeAdded(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhonebookEntry[] ListEntries(int startIndex, int entriesCount);
    }
}