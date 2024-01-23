using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public int CollectorsCollected = 0;
    public GameObject Storage;

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
            Debug.Log("AGGG");
            this.gameObject.SetActive(false);
        }
    }
}
