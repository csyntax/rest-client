using System.Runtime.Serialization;

namespace RestClient
{
    
    [DataContract(Name="repo")]
    public class Repository
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
    }
}