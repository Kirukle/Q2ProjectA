using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefab : MonoBehaviour
{
    public float deleteTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteThing());
    }
    IEnumerator DeleteThing()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
