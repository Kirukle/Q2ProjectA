using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour
{
    public int Collectors;
    // Update is called once per frame
    void Update()
    {
        if (Collectors > 3)
        {
            Debug.Log("Completed");
        }
    }
}
