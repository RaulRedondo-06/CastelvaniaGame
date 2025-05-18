using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MongoAPIClient : MonoBehaviour
{
    private string apiUrl = "http://localhost:8086/top6";

    void Start()
    {
        StartCoroutine(GetTop6Data());
    }

    IEnumerator GetTop6Data()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error en la petición: " + request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("Datos recibidos: " + jsonResponse);

            // Parsear el JSON a array de PlayerData
            PlayerData[] players = JsonHelper.FromJson<PlayerData>(jsonResponse);

            // Mostrar los datos recibidos
            foreach (PlayerData p in players)
            {
                Debug.Log($"Nombre: {p.name}, Score: {p.score}, Tiempo: {p.played_time}");
            }
        }
    }
}
