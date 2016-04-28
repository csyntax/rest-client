using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

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
                
                var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
                
                var streamTask = client.GetStreamAsync("https://api.github.com/users/csyntax/repos");
                var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
                
                foreach (var repository in repositories)
                {
                    Console.WriteLine(repository.Name);
                }
        }

        public static void Main(string[] args)
        {
            ProcessRepositories().Wait();
        }
    }
}