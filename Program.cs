using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestClient
{
    public class Program
    {
        private static async Task ProcessRepositories()
        {
            var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", "csyntax RestClient");

                var stringTask = client.GetStringAsync("https://api.github.com/users/csyntax/repos");
                var msg = await stringTask;
                
                Console.Write(msg);
        }

        public static void Main(string[] args)
        {
            ProcessRepositories().Wait();
        }
    }
}