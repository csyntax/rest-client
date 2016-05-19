using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RestClient
{
    [DataContract(Name = "repo")]
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "language")]
        public string Language { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.Name, this.Language);
        }

        public static async Task<List<Repository>> ProcessRepositories()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "csyntax");

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
            var streamTask = client.GetStreamAsync("https://api.github.com/users/csyntax/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;

            return repositories;
        }
    }
}
