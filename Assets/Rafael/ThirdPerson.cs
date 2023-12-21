using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPerson : MonoBehaviour
{

    private const float YMin = -4.46f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;

   

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivity = 40.0f;

    public float speed = 0f;
    Vector3 badDistance;
    Vector3 goodDistance;

    public GameObject WallObject;

    


   

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

       
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            //    Debug.Log(hit.collider.gameObject);
            //if(hit.transform.gameObject.tag == "Enemy")
            //{
            //    GameObject.Find("SillyMan").GetComponent<UnityPatrol>().enabled = false;
            //    GameObject.Find("SillyMan").GetComponent<Followplayer>().enabled = true;

            //}
            //Debug.DrawLine(ray.origin, hit.point);
            

            if (hit.transform.gameObject.tag == "BlockWall")
            {

                WallObject = hit.transform.gameObject;

                WallObject.GetComponent<MeshRenderer>().enabled = false;

            }
            else
            {

                WallObject.GetComponent<MeshRenderer>().enabled = true;

            }//Now all I gotta do is figure out how to ignore colliders that are not the tag I want it to affect
            
                





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
