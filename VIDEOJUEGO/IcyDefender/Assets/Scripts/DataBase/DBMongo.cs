using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using JetBrains.Annotations;

public class DBMongo : MonoBehaviour
{
    private static MongoClient _client;
    private IMongoDatabase _database;
    private static IMongoCollection<ModelPlayer> _collection;
    public static DBMongo DBMongoInstance;
    private string iIdPlayer = "654c7fa348d4f7850b97125b";

    private void Awake()
    {
        if (DBMongoInstance == null)
        {
            DBMongoInstance = this;
            DontDestroyOnLoad(DBMongoInstance);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _client = new MongoClient("mongodb+srv://unity:unity@atlascluster.jubnchd.mongodb.net/?retryWrites=true&w=majority");
            _database = _client.GetDatabase("DB_IcyDefender");
            _collection = _database.GetCollection<ModelPlayer>("Player");
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR DBMongo: " +  e.Message);
            _client = null;
        }
    }

    // TODO
    public void login(string sNickname, string sPassword)
    {
        
    }

    public int ObtenerScorePorId()
    {
        int score = 0;

        if (_client != null)
        {
            try
            {
                var filter = Builders<ModelPlayer>.Filter.Eq("_id", new ObjectId(DBMongoInstance.iIdPlayer));
                var result = _collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    score = result.Score;
                }
                else
                {
                    Debug.Log("No se encontró el jugador con el ID proporcionado.");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("ERROR: " + e.Message);
            }
        }

        return score;
    }

    public static void ActualizarScore(int iPuntuacion)
    {
        if (_client != null)
        {
            try
            {
                if (DBMongoInstance.ObtenerScorePorId() < iPuntuacion)
                {
                    // Define el filtro para identificar el documento que deseas actualizar
                    var filter = Builders<ModelPlayer>.Filter.Eq("_id", new ObjectId(DBMongoInstance.iIdPlayer));
                    // Crea un documento de actualización con los cambios deseados
                    var update = Builders<ModelPlayer>.Update.Set("Score", iPuntuacion);
                    // Ejecuta la operación de actualización
                    _collection.UpdateOne(filter, update);
                }

            }
            catch (System.Exception e)
            {
                Debug.Log("ERROR: " + e.Message);
            }

        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
