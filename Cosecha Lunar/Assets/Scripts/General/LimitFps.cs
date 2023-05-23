using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFps : MonoBehaviour
{
    [SerializeField] private limits limit;

    private enum limits
    {
        noLimits = 0,
        limitTo30 = 30,
        limitTo60 = 60,
        limitTo120 = 120
    }
    private void Start()
    {
        //Application.targetFrameRate = Screen.currentResolution.refreshRate;
        HazAlgo();
    }
    void HazAlgo()
    {
        Application.targetFrameRate = (int)limit;
    }
}
