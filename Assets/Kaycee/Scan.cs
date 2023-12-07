using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float ScanRadius;
    public LayerMask CanBeScanned;
    public int WaitTime;
    private bool onCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2) && onCooldown == false)
        { 
            DrawRadiusCircle();
            onCooldown = true;
        }
    }
    IEnumerator ScanCooldown()
    {
        yield return new WaitForSeconds(WaitTime);
        onCooldown = false;
    }
    void DrawRadiusCircle()
    {
        StartCoroutine(ScanCooldown());
        Collider[] PossibleScanDetection = Physics.OverlapSphere(transform.position, ScanRadius, CanBeScanned);
        foreach (Collider col in PossibleScanDetection)
        {

            
            col.GetComponent<Scanable>().activated = true;
            
            
        }
        
    }
}
