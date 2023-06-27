using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTesting : MonoBehaviour
{
    public GameObject arenas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            arenas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            arenas.SetActive(true);
        }
    }
}
