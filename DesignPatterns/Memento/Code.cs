namespace Memento
{
    using System;
    using System.Linq;

    public class Code : ICode
    {
        private string codeAsText;

        public Code()
        {
        }

        public string CodeAsText
        {
            get
            {
                return this.codeAsText;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Code cannot be null or empty.");
                }

                this.codeAsText = value;
            }
        }

        public void Save(string code)
        {
            this.CodeAsText = code;
        }

        public override string ToString()
        {
            return this.CodeAsText;
        }
    }
}