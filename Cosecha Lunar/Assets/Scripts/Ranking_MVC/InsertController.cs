using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InsertController : MonoBehaviour
{
   

    IEnumerator SendRequest()
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/prograProm3/ProgramaciónFinal/ProgramaciónFinal_InsertScore.php"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                
            }
        }

    }
}
