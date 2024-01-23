using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPerson : MonoBehaviour
{
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;

    
   

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivity = 400.0f;

    public float speed = 0f;
    Vector3 badDistance;
    Vector3 goodDistance;

    public GameObject WallObject;
    public GameObject PrevObject;
    public GameObject NextObject;

    public GameObject[] WallObjects;
    public GameObject[] PrevObjects;
    public GameObject[] NextObjects;












    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        

    }

    public void FixedUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("BlockWall");


        if (Input.GetKey(KeyCode.Equals))
        {
            sensitivity = 4000.0f;


        }

        //raycast which detects if wall that interrupts raycast looking at player has the BlockWall Layer
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 10, mask);
        //if (Physics.Raycast(ray, out hit, 10, mask)
        for(int i = 0; i< hits.Length; i++)
        {

            RaycastHit hit = hits[i];

            NextObject = hit.transform.gameObject;
            if (NextObject != WallObject)
            {
                PrevObject = WallObject;
                WallObject = NextObject;


            }

           
            WallObject.GetComponent<MeshRenderer>().enabled = false;
            PrevObject.GetComponent<MeshRenderer>().enabled = true;

        }

        if (hits.Length == 0)
        {

            NextObject.GetComponent<MeshRenderer>().enabled = true;

        }

        //{


        //    Debug.Log(hit.collider.gameObject);
        //if(hit.transform.gameObject.tag == "Enemy")
        //{
        //    GameObject.Find("SillyMan").GetComponent<UnityPatrol>().enabled = false;
        //    GameObject.Find("SillyMan").GetComponent<Followplayer>().enabled = true;

        //}
        //Debug.DrawLine(ray.origin, hit.point);





        //Stores the object that was last hit by the raycast
        //    if(NextObject != WallObject)
        //    {
        //        PrevObject = WallObject;
        //        WallObject = NextObject;


        //    }





        //    //Color nocolor = WallObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
        //    //nocolor.a = 0;

        //    //Color color = PrevObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
        //    //color.a = 1;
        //    //turns current wall invisible, makes previous wall that was invisible visible
        //    WallObject.GetComponent<MeshRenderer>().enabled = false;   /*material.SetColor("_Color", nocolor);*/
        //    PrevObject.GetComponent<MeshRenderer>().enabled = true;       /*material.SetColor("_Color", color);*/

        //    //if (hit.transform.gameObject.tag == "BlockWall")
        //    //{


        //    //} 


        //    //Now all I gotta do is figure out how to ignore colliders that are not the tag I want it to affect









        //}
        //else
        //{
        //    // Color keepcolor = NextObject.GetComponent<MeshRenderer>().material.GetColor("_Color");

        //    //keepcolor.a = 1;
        //    //Makes sure the wall turns visible when going to another wall or back to looking at player
        //    NextObject.GetComponent<MeshRenderer>().enabled = true;


        //}





    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;
        transform.LookAt(lookAt.position);

      



    }

    

        

    
}
