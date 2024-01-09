using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField]
    private Image _NoteObj;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        _NoteObj.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
            _NoteObj.enabled = false;
    }

}
