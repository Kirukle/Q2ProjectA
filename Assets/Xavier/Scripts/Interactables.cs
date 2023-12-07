using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onScan;

    public void Scan()
    {
        onScan.Invoke();
    }
}