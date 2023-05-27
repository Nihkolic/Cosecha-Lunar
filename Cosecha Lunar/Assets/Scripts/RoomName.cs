using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomName : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    public string roomName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomNameText.text = "Area: " + roomName;
            Debug.Log(roomName);
        }
    }
}
