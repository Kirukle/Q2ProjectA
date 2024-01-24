using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StorageScript : MonoBehaviour
{
    public int Collectors;
    // Update is called once per frame
    void Update()
    {
        if (Collectors > 3)
        {
            Debug.Log("Completed");
            SceneManager.LoadScene("EndingScene");
        }
    }
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 4 / 100);
        style.alignment = TextAnchor.LowerCenter;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0f, 0f, 0.5f, 1.0f);
        string text = "MISSION OPERATION :  " + Collectors.ToString() + "/4";
        GUI.Label(rect, text, style);
    }
}
