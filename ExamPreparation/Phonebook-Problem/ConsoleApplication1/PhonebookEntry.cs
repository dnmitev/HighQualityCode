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

        public SortedSet<string> Strings;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');

            sb.Append(this.Name);
            bool flag = true;
            foreach (var phone in this.Strings)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            return sb.ToString();
        }

        public int CompareTo(PhonebookEntry otherEntry)
        {
            return this.name.CompareTo(otherEntry.name.ToLowerInvariant());
        }
    }
}