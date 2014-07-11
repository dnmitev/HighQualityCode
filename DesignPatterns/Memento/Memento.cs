namespace Memento
{
    using System;
    using System.Linq;

    public class Memento
    {
        public Memento(ICode code, string committdBy, string message)
        {
            this.Code = code;
            this.Committer = committdBy;
            this.CommitMessage = message;
            this.Date = DateTime.Now;
        }

        public ICode Code { get; set; }

        public string Committer { get; set; }

        public string CommitMessage { get; set; }

        public DateTime Date { get; set; }
    }
}