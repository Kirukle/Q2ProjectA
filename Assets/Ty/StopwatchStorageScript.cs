using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopwatchStorageScript : MonoBehaviour
{
    public TMP_Text timeText;
    public int SWminutes;
    public int SWseconds;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("StopwatchTimeMinutes", 1);
        PlayerPrefs.SetInt("StopwatchTimeSeconds", 11);
       SWminutes =  PlayerPrefs.GetInt("StopwatchTimeMinutes");
       SWseconds = PlayerPrefs.GetInt("StopwatchTimeSeconds");

        string timeText = ("Completed in " + SWminutes.ToString() + ":" + SWseconds.ToString() + " sec");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
