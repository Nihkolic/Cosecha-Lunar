using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //[SerializeField] private float spinTimer = 5f;
    [SerializeField] private float spinSpeed = 100f;

    [SerializeField] private float bounceSpeed = 1.0f;
    [SerializeField] private float height = 0.2f;  

    private Vector3 _startPos;
    void Start()
    {
        _startPos = transform.position;
    }
    void Update()
    {
        //StartCoroutine(Rotate());
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);

        float newY = _startPos.y + Mathf.Sin(Time.time * bounceSpeed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }/*
    IEnumerator Rotate()
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < spinTimer)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / spinTimer) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }*/
}
