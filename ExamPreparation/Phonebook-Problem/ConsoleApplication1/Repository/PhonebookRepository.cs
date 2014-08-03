namespace Phonebook.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository, IDeletablePhonebookRepository
    {
        private readonly OrderedSet<PhonebookEntry> sorted = new OrderedSet<PhonebookEntry>();
        private readonly Dictionary<string, PhonebookEntry> dict = new Dictionary<string, PhonebookEntry>();
        private readonly MultiDictionary<string, PhonebookEntry> multidict = new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string invartiantName = name.ToLowerInvariant();
            PhonebookEntry entry;
            bool isNewEntry = !this.dict.TryGetValue(invartiantName, out entry);
            if (isNewEntry)
            {
                entry = new PhonebookEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.dict.Add(invartiantName, entry);

                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);
            return isNewEntry;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.PhoneNumbers.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhonebookEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }

            PhonebookEntry[] list = new PhonebookEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PhonebookEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }

        public bool Remove(string phoneNumber)
        {
            var dictionaryCopy = this.dict.ToArray();
            foreach (var entry in dictionaryCopy)
            {
                entry.Value.PhoneNumbers.Remove(phoneNumber);
                if (entry.Value.PhoneNumbers.Count == 0)
                {
                    this.dict.Remove(entry.Key);
                }
            }

            return true;
        }
    }
}