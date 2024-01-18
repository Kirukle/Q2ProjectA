using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 240);
        Application.targetFrameRate = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}