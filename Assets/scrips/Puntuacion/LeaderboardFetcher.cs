using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardFetcher : MonoBehaviour
{
    public LeaderboardUI leaderboardUI;

    private void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8081/top6"));
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error en la solicitud: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            PlayerData[] players = JsonHelper.FromJson<PlayerData>(json);
            leaderboardUI.SetLeaderboard(players);
        }
    }
}
