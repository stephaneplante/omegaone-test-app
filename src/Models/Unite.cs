using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace omegaone_test_app.Models
{
    [FirestoreData]
    public class Unite
    {
        [FirestoreDocumentId]
        [JsonProperty("id")]
        public string Id { get; set; }

        [FirestoreProperty("nom")]
        [JsonProperty("nom")]
        public string Nom { get; set; }

        [FirestoreProperty("ordreAffichage")]
        [JsonProperty("ordreAffichage")]
        public int OrdreAffichage { get; set; }
    }
}