using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankingController : MonoBehaviour
{
    [SerializeField]
    private RankingArrayData rankingArrayData;
    public void GetRanking(Action<RankingArrayData> callback)
    {
        StartCoroutine(SendRankingRequest(callback));
    }

    IEnumerator SendRankingRequest(Action<RankingArrayData> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/prograProm3/ProgramaciónFinal/ProgramaciónFinal_Ranking.php"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                rankingArrayData = JsonUtility.FromJson<RankingArrayData>(www.downloadHandler.text);
                callback?.Invoke(rankingArrayData);
            }
        }

    }
}
