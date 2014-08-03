using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    internal class REPNew : IPhonebookRepository
    {
        public List<PhonebookEntry> entries = new List<PhonebookEntry>();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var old = from e in this.entries where e.Name.ToLowerInvariant() == name.ToLowerInvariant() select e;

            bool flag;
            if (old.Count() == 0)
            {
                PhonebookEntry obj = new PhonebookEntry();
                obj.Name = name;
                obj.Strings = new SortedSet<string>();

                foreach (var num in nums)
                {
                    obj.Strings.Add(num);
                }

                this.entries.Add(obj);

                flag = true;
            }
            else if (old.Count() == 1)
            {
                PhonebookEntry obj2 = old.First();
                foreach (var num

                    in nums)
                {
                    obj2.Strings.Add(num);
                }

                flag = false;
            }
            else
            {
                Console.WriteLine(string.Format("Duplicated name in the phonebook found: {0}", name));
                return false;
            }

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in this.entries where e.Strings.Contains(oldent) select e;

            int nums = 0;
            foreach (var entry

                in list)
            {
                entry.Strings.Remove(oldent);
                entry.Strings.Add(newent);
                nums++;
            }

            return nums;
        }

        public PhonebookEntry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();
            PhonebookEntry[] ent = new PhonebookEntry[num];
            for (int i = start; i <= start + num - 1; i++)
            {
                PhonebookEntry entry = this.entries[i];
                ent[i -
                    start] = entry;
            }

            return ent;
        }
    }
}