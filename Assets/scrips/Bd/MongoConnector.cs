using MongoDB.Driver;
using MongoDB.Bson;
using UnityEngine;

public class MongoConnector : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;

    void Start()
    {
        string connectionString = "mongodb+srv://Raul:raul%2E2006@castlevaniacluster.pp8gjpl.mongodb.net/?retryWrites=true&w=majority&appName=CastlevaniaCluster";
        client = new MongoClient(connectionString);

        // Cambia "CastelvaniaDB" por el nombre real de tu base de datos
        database = client.GetDatabase("CastelvaniaDB");

        InsertarDocumento("miColeccion");
    }

    void InsertarDocumento(string coleccion)
    {
        var collection = database.GetCollection<BsonDocument>(coleccion);

        // Crea un documento BSON
        var nuevoDoc = new BsonDocument
        {
            { "nombre", "Jugador1" },
            { "puntuacion", 100 },
            { "fecha", System.DateTime.Now }
        };

        // Inserta el documento
        collection.InsertOne(nuevoDoc);

        Debug.Log("Documento insertado con éxito.");
    }
}
