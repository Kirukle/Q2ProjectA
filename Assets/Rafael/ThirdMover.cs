using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdMover : MonoBehaviour
{

    
   public CharacterController Controller;

    public float speed;

    public float sprint;

    public bool CanMove;

    public Transform Cam;

    public bool CanSprint;

    public float DirectionHorizon;
    public float DirectionVertical;

    public int rotationnew = 180;

    public GameObject Bobot;

    public float rotationspeed = 4.0f;

    private Animator PlayerAnim;

    // Start is called before the first frame update
    void Start()
    {
        Controller.GetComponent<CharacterController>();
        PlayerAnim = Bobot.GetComponent<Animator>();

        //from.rotation = transform.rotation;
        //to.rotation = rotationnew;
    }

    // Update is called once per frame
    void Update()
    {


        

        if (CanMove == true)
        {



            float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            DirectionHorizon = Horizontal;
            DirectionVertical = Vertical;
            Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;

            Movement.y = 0f;

            if (Movement != Vector3.zero)
            {
                transform.forward = Vector3.Slerp(transform.forward, Movement, rotationspeed * Time.deltaTime);
                PlayerAnim.SetBool("Walking", true);
                PlayerAnim.SetBool("Stopped", false);
                //Quaternion.Slerp(transform.rotation, Movement, rotationspeed);
            }
            else
            {
                PlayerAnim.SetBool("Walking", false);
                PlayerAnim.SetBool("Stopped", true);


            }
            Controller.Move(Movement);

            

            //if (Movement.magnitude != 0f)
            //{
            //    transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<ThirdPerson>().sensitivity * Time.deltaTime);
            //    Quaternion CamRotation = Cam.rotation;
            //    CamRotation.x = 0f;
            //    CamRotation.z = 0f;

            //    transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);



            //}

            if (Input.GetKey(KeyCode.LeftShift) && CanSprint == true)
            {

                speed = sprint;
                PlayerAnim.SetBool("Running", true);

            }
            else
            {

                speed = 10.0f;
                PlayerAnim.SetBool("Running", false);
            }

        }



    }
  
}
