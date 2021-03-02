using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace omegaone_test_app.Models
{
    [FirestoreData]
    public class TypeDepense
    {
        [FirestoreDocumentId]
        [JsonProperty("id")]
        public string Id { get; set; }

        [FirestoreProperty("description")]
        [JsonProperty("descrition")]
        public string Description { get; set; }

        [FirestoreProperty("ordreAffichage")]
        [JsonProperty("ordreAffichage")]
        public int OrdreAffichage { get; set; }
    }
}