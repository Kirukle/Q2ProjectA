using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastStuff : MonoBehaviour
{



    public UnityEvent EventTest;



    //public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit info, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);
    // Start is called before the first frame update

    // Update is called once per frame
    public void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000000000))
        {
            //    Debug.Log(hit.collider.gameObject);
            //if(hit.transform.gameObject.tag == "Enemy")
            //{
            //    GameObject.Find("SillyMan").GetComponent<UnityPatrol>().enabled = false;
            //    GameObject.Find("SillyMan").GetComponent<Followplayer>().enabled = true;

            //}
            //Debug.DrawLine(ray.origin, hit.point);
            if (hit.transform.gameObject.tag == "Enemy")
                EventTest.Invoke();


        }

       // if (Physics.Raycast(ray, out hit, 1000))
          //  print("Object found, distance is" + hit.distance);



        



    }
    
}
