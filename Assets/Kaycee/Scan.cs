using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float ScanRadius = 5f;
    public LayerMask CanBeScanned;
    public int WaitTime;
    private bool onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && onCooldown == false)
        {
            Debug.Log("test");
            DrawRadiusCircle();
            onCooldown = true;
        }
    }
    IEnumerator ScanCooldown()
    {
        Debug.Log("counting");
        yield return new WaitForSeconds(WaitTime);
        onCooldown = false;
    }
    void DrawRadiusCircle()
    {
        StartCoroutine(ScanCooldown());
        Debug.Log("drawing");
        Collider[] PossibleScanDetection = Physics.OverlapSphere(transform.position, ScanRadius, CanBeScanned);
        foreach (Collider col in PossibleScanDetection)
        {
            col.GetComponent<Scanable>().activated = true;
        }
    }

}