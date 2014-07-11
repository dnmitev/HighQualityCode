namespace Memento
{
    using System;
    using System.Linq;

    public class Demo
    {
        private static void Main()
        {
            ICode initialCode = new Code();
            string initialCodeString =
                @"namespace Memento
  {
      public interface ICode
      {
          string CodeAsText { get; }
  
          void Save(string code);
      }
  }";

            initialCode.Save(initialCodeString);

            ICode laterCode = new Code();
            string laterCodeString =
                @"namespace Memento
  {
      using System;
      using System.Linq;
  
      public class RepositoryMemory
      {
          public Memento Memento { get; set; }
      }
  }";

            laterCode.Save(laterCodeString);

            var repo = new CodeRepository(initialCode, "Pesho", "Magic - DO NOT TOUCH");

            Console.WriteLine(repo);

            var memory = new RepositoryMemory();
            memory.Memento = repo.SaveMemento();

            repo.Commit(laterCode, "Grisho", "I've touched your magic");
            Console.WriteLine(repo);

            repo.RevertMemento(memory.Memento);
            Console.WriteLine(repo);
        }
    }
}