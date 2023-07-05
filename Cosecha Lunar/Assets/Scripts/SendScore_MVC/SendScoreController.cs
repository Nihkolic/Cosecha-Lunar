using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendScoreController : MonoBehaviour
{
    public void SendScore(string username, int score, Action callback)
    {
        StartCoroutine(SendScoreRequest(username, score, callback));
    }
    IEnumerator SendScoreRequest(string username, int score, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre", username);
        form.AddField("puntos", score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograProm3/ProgramaciónFinal/ProgramaciónFinal_InsertScore.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                callback?.Invoke();
               
            }
        }

    }
}
