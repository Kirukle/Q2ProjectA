using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopwatchStorageScript : MonoBehaviour
{
    public TMP_Text timeText;
    public float SWmins;
    public float SWsecs;
    public GameObject Stopwatch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SWmins = Stopwatch.GetComponent<StopwatchTimerScript>().SWmins;
        SWsecs = Stopwatch.GetComponent<StopwatchTimerScript>().SWsecs;

        timeText.text = ("Completed in " + SWmins.ToString() + ":" + SWsecs.ToString() + " sec");
    }
}
