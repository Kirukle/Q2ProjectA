using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy : MonoBehaviour
{



    public Vector3 Direction;
    public CharacterController characterController;
    private Vector3 velocity;
    public float Speed = 2f;
    public float jump = 10f;
    public float Gravity = -9.8f;
    public bool canJump;
    public GameObject player;

    public AnimationCurve Test;
    public float jumpTime;
    public AnimationCurve Climb;
    public float climbTime;

    [Header("Boxcast Settings")]
    public Vector3 size;
    public float offset;
    public float m_MaxDistance = 0.09f;
    public Vector3 offsetpos1;
    public Vector3 offsetpos2;
    public Vector3 offsetpos3;
    public Vector3 sizeclimb;
    public float climb_MaxDistance = 0.09f;


    public LayerMask ClimbWall;
    public bool CanClimb;
    public bool Grounded => Physics.BoxCast(transform.position + offsetpos1, size / 2, Vector3.down * offset, Quaternion.identity, m_MaxDistance);
    public bool Ceiling => Physics.BoxCast(transform.position + offsetpos2, size / 2, Vector3.up * offset, Quaternion.identity, m_MaxDistance);

    public bool Climbable => Physics.BoxCast(transform.position + offsetpos3, sizeclimb / 2, transform.forward * offset, Quaternion.identity, climb_MaxDistance, ClimbWall);



    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {

        Vector3 movementDirection = new Vector3(player.GetComponent<ThirdMover>().DirectionHorizon, 0, player.GetComponent<ThirdMover>().DirectionVertical);

       


        //float horizontal = Input.GetAxis("Horizontal") * Speed;
        //float vertical = Input.GetAxis("Vertical") * Speed;
        //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //characterController.Move(move * Speed * Time.deltaTime);


        Test.Evaluate(0.5f);
        Climb.Evaluate(0.5f);

        if (Input.GetButtonDown("Jump") && Grounded && canJump == true)
        {
            jumpTime = 0;


        }
        else
        {

             velocity.y += Gravity * Time.deltaTime;
            



        }
        if (Input.GetButton("Jump") && Grounded)
        {
            jumpTime += Time.deltaTime;
            velocity.y = Test.Evaluate(jumpTime);
            



        }
        else if (Input.GetButtonUp("Jump") && Grounded )
        {

            jumpTime = 0;

        }
        
            characterController.Move(velocity * Time.deltaTime);
        if (Grounded)
        {
            velocity.y = 0;

        }

        if (Ceiling)
        {
            velocity.y = -3;

        }

        if (Input.GetKey(KeyCode.W) && Climbable && CanClimb == true)
        {

            climbTime += Time.deltaTime;
            velocity.y = Climb.Evaluate(climbTime);

        }
        else if (Input.GetKeyUp(KeyCode.W) || Climbable == false)
        {

            climbTime = 0;

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + offsetpos1 + Vector3.down * offset, size);
        Gizmos.DrawWireCube(transform.position + offsetpos2 + Vector3.up * offset, size);
        Gizmos.DrawWireCube(transform.position + offsetpos3 + transform.forward * offset, sizeclimb);
    }
}
