using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using omegaone_test_app.Models;

namespace omegaone_test_app.Controllers
{
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;
        private readonly FirestoreDb _db;

        public DataController(ILogger<DataController> logger, FirestoreDb db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var parametres = new List<Parametre>();
            CollectionReference parametresRef = _db.Collection("parametres");

            QuerySnapshot snapshot = await parametresRef.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                var parametre = document.ConvertTo<Parametre>();

                var liste = document.Reference.ListCollectionsAsync();
                await foreach (CollectionReference collectionRef in liste)
                {
                    var snapshotRef = await collectionRef.GetSnapshotAsync();

                    foreach(var documentRef in snapshotRef.Documents)
                    {
                        switch(collectionRef.Id)
                        {
                            case "taux":
                                parametre.Taux.Add(documentRef.ConvertTo<Taux>());
                                break;
                            case "types-depenses":
                                parametre.TypesDepenses.Add(documentRef.ConvertTo<TypeDepense>());
                                break;
                            case "types-revenus":
                                parametre.TypesRevenus.Add(documentRef.ConvertTo<TypeRevenu>());
                                break;
                            case "unites":
                                parametre.Unites.Add(documentRef.ConvertTo<Unite>());
                                break;
                        }
                    }                    
                }
                parametres.Add(parametre);
            }
            return Ok(parametres);
        }
    }
}