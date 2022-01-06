using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace omegaone_test_app.Models
{
    [FirestoreData]
    public class Taux
    {
        [FirestoreDocumentId]
        [JsonProperty("id")]
        public string Id { get; set; }

        [FirestoreProperty("valeur")]
        [JsonProperty("valeur")]
        public double Valeur { get; set; }
    }
}