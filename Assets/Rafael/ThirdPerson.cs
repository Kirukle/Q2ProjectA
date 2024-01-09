using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPerson : MonoBehaviour
{
    private const float YMin = -4.46f;
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

     
    RaycastHit hit;











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
        RaycastHit hit;


        if (Input.GetKey(KeyCode.Equals))
        {
            sensitivity = 4000.0f;


        }

        //raycast which detects if wall that interrupts raycast looking at player has the BlockWall Layer
        if (Physics.Raycast(ray, out hit, 10,mask))
        {
           

            //    Debug.Log(hit.collider.gameObject);
            //if(hit.transform.gameObject.tag == "Enemy")
            //{
            //    GameObject.Find("SillyMan").GetComponent<UnityPatrol>().enabled = false;
            //    GameObject.Find("SillyMan").GetComponent<Followplayer>().enabled = true;

            //}
            //Debug.DrawLine(ray.origin, hit.point);

           

           NextObject = hit.transform.gameObject;

            //Stores the object that was last hit by the raycast
            if(NextObject != WallObject)
            {
                PrevObject = WallObject;
                WallObject = NextObject;


            }

           
            
           

            //Color nocolor = WallObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
            //nocolor.a = 0;

            //Color color = PrevObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
            //color.a = 1;
            //turns current wall invisible, makes previous wall that was invisible visible
            WallObject.GetComponent<MeshRenderer>().enabled = false;   /*material.SetColor("_Color", nocolor);*/
            PrevObject.GetComponent<MeshRenderer>().enabled = true;       /*material.SetColor("_Color", color);*/

            //if (hit.transform.gameObject.tag == "BlockWall")
            //{


            //} 


            //Now all I gotta do is figure out how to ignore colliders that are not the tag I want it to affect









        }
        else
        {
            // Color keepcolor = NextObject.GetComponent<MeshRenderer>().material.GetColor("_Color");

            //keepcolor.a = 1;
            //Makes sure the wall turns visible when going to another wall or back to looking at player
            NextObject.GetComponent<MeshRenderer>().enabled = true;


        }
       




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
