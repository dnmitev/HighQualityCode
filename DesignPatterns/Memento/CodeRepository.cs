namespace Memento
{
    using System;
    using System.Linq;
    using System.Text;

    public class CodeRepository
    {
        public CodeRepository(ICode code, string committdBy, string message)
        {
            this.Code = code;
            this.Committer = committdBy;
            this.CommitMessage = message;
            this.Date = DateTime.Now;
        }

        public ICode Code { get; private set; }

        public string Committer { get; private set; }

        public string CommitMessage { get; private set; }

        public DateTime Date { get; private set; }

        public void Commit(ICode code, string commiter, string message)
        {
            this.Code = code;
            this.Committer = commiter;
            this.CommitMessage = message;
            this.Date = DateTime.Now;
        }

        public Memento SaveMemento()
        {
            Console.WriteLine("Successfully committd!");

            return new Memento(this.Code, this.Committer, this.CommitMessage);
        }

        public void RevertMemento(Memento memento)
        {
            Console.WriteLine("Reverted!");

            this.Code = memento.Code;
            this.Committer = memento.Committer;
            this.CommitMessage = memento.CommitMessage;
            this.Date = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Committed by: {0} on {1}", this.Committer, this.Date));
            sb.AppendLine(string.Format("Message: {0}", this.CommitMessage));
            sb.AppendLine(this.Code.ToString());

            return sb.ToString();
        }
    }
}