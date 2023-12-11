using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanable : MonoBehaviour
{
    public bool activated;
    public GameObject textPrefab;
    public float scanTime;
    public string TextName;

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            Instantiate(textPrefab).GetComponent<TMPro.TMP_Text>().SetText(TextName);
        }
    }
}