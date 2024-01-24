using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopwatchTimerScript : MonoBehaviour
{

    public float timeRemaining = 0;
    public bool timeIsRunning = false;
    public int minutes;
    public int seconds;


    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining >= 0)
        {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
        }

        PlayerPrefs.SetInt("StopwatchTimeMinutes", minutes);
        PlayerPrefs.SetInt("StopwatchTimeSeconds", seconds);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        

        string text = string.Format("{0:00} : {1:00}",minutes , seconds);
        GUI.Label(rect, text, style);
    }


}
