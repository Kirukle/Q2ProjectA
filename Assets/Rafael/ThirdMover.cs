using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMover : MonoBehaviour
{

    
   public CharacterController Controller;

    public float speed;

    public bool CanMove;

    public Transform Cam;

    // Start is called before the first frame update
    void Start()
    {
        Controller.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

      if(CanMove == true)
        {



            float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;


            Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;

            Movement.y = 0f;

            Controller.Move(Movement);

            if (Movement.magnitude != 0f)
            {
                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<ThirdPerson>().sensitivity * Time.deltaTime);
                Quaternion CamRotation = Cam.rotation;
                CamRotation.x = 0f;
                CamRotation.z = 0f;

                transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);



            }



        }


        
    }


  
}
