using System.Collections.Generic;

namespace GitHookController.Models
{
    // ReSharper disable InconsistentNaming

    public class HookModel
    {
        public string before { get; set; }
        public Repository repository { get; set; }
        public List<Commit> commits { get; set; }
        public string after { get; set; }
        public string @ref { get; set; }

        public class Owner
        {
            public string email { get; set; }
            public string name { get; set; }
        }

        public class Repository
        {
            public string url { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int watchers { get; set; }
            public int forks { get; set; }
            public bool @private { get; set; }
            public Owner owner { get; set; }
        }

        public class Author
        {
            public string email { get; set; }
            public string name { get; set; }
        }

        public class Commit
        {
            public string id { get; set; }
            public string url { get; set; }
            public Author author { get; set; }
            public string message { get; set; }
            public string timestamp { get; set; }
            public List<string> added { get; set; }
        }
    }
}