using System.Collections.Generic;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace omegaone_test_app.Models
{
    [FirestoreData]
    public class Parametre
    {
        [FirestoreDocumentId]
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [FirestoreProperty("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("taux")]
        public List<Taux> Taux { get; set; } = new List<Taux>();

        [JsonProperty("types-depenses")]
        public List<TypeDepense> TypesDepenses { get; set; } = new List<TypeDepense>();

        [JsonProperty("types-revenus")]
        public List<TypeRevenu> TypesRevenus { get; set; } = new List<TypeRevenu>();

        [JsonProperty("unites")]
        public List<Unite> Unites { get; set; } = new List<Unite>();
    }
}