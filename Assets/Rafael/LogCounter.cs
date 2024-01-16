using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCounter : MonoBehaviour
{
    public ScannableObj scannableObj;

    private void OnTriggerEnter(Collider collision)
    {

        //check here for player
        scannableObj.Apply(collision.gameObject);
        Destroy(gameObject);
    }

}
