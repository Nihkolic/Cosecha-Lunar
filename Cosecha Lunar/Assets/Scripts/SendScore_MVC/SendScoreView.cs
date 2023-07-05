using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SendScoreView : MonoBehaviour
{
    private SendScoreController controller;

    private void OnEnable()
    {
        controller = GetComponent<SendScoreController>();
    }

    public void OnSendScore(string name, int score)
    {
        controller.SendScore(name, score, OnFinishRequest);


        Debug.Log(name+""+ score);
    }

    private void OnFinishRequest()
    {
        Debug.Log("request done");
    }
}
