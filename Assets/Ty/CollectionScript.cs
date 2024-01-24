using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public int CollectorsCollected = 0;
    public GameObject Storage;
    public GameObject Stopwatch;
    public GameObject VHS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Collector")
        {
            Storage.GetComponent<StorageScript>().Collectors++;
            Stopwatch.GetComponent<CollectStorageScript>().Collectors++;

            Debug.Log("AGGG");
            VHS.SetActive(false);
        }
    }
}
