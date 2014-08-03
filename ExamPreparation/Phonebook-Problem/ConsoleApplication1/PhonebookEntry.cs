namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentOutOfRangeException("Name cannot exceed 200 characters");
                }
                else if (value.IndexOf(',') > 0 || value.IndexOf(':') > 0 || value.IndexOf("\n") > 0)
                {
                    throw new ArgumentException("Phone entry name cannot contain symbols ',', ':' or '\\n'.");
                }

                this.name = value.Trim();
            }
        }

        // TODO: Check this one
        public SortedSet<string> PhoneNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder entry = new StringBuilder();
            entry.Clear();
            entry.Append('[');

            entry.Append(this.Name);
            bool isFirstPhoneNumber = true;
            foreach (var phoneNumber in this.PhoneNumbers)
            {
                if (isFirstPhoneNumber)
                {
                    entry.Append(": ");
                    isFirstPhoneNumber = false;
                }
                else
                {
                    entry.Append(", ");
                }

                entry.Append(phoneNumber);
            }

            entry.Append(']');
            return entry.ToString();
        }

        public int CompareTo(PhonebookEntry otherEntry)
        {
            return this.name.CompareTo(otherEntry.name.ToLowerInvariant());
        }
    }
}