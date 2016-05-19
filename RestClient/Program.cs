using System;

namespace RestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repositories = Repository.ProcessRepositories().Result;

            foreach (var repository in repositories)
            {
                Console.WriteLine(repository);
            }
        }
    }
}
