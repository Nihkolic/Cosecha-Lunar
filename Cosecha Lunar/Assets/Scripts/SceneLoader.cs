using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName;


    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(sceneName); });
    }


}
