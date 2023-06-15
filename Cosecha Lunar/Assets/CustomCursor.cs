using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    Vector2 targetPos;
    void Start()
    {
        
    }
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;

        /*
        targetPos = Input.mousePosition;
        targetPos.z = 3;
        transform.position = Camera.main.ScreenToWorldPoint(targetPos);*/
    }
}
