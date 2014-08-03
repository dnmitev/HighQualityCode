namespace Phonebook.Repository
{
    using System.Collections.Generic;
    using Phonebook;

    /// <summary>
    /// Main logic of a phonebook repository. 
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Check whether an entry can be added as new or it is already available on the current phonebook
        /// </summary>
        /// <param name="name">Phonebook entry's name as a string</param>
        /// <param name="phoneNumbers">Phone entry's available phones as a collection of strings</param>
        /// <returns>If the phone entry can be added to the phonebook as a boolean</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes given phone number to new one and returns the count of the changed phone numbers
        /// </summary>
        /// <param name="oldPhoneNumber">phone number to be changed as a string</param>
        /// <param name="newPhoneNumber">new phone number as a string</param>
        /// <returns>The count of all found numbers that are changed</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// By given start index of phonenumber and total count of phone numbers returns a collection of phone entries
        /// </summary>
        /// <param name="startIndex">index of the first number in the wanted filter</param>
        /// <param name="entriesCount">count of the numbers</param>
        /// <returns>An array of phonebook entries</returns>
        PhonebookEntry[] ListEntries(int startIndex, int entriesCount);
    }
}