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

    bool JumpEnd;

    float currentY;
    float nextY;
    float prevY;
    

    public AnimationCurve Test;
    public float jumpTime;
    public AnimationCurve Climb;
    public float climbTime;
    public GameObject Bobot;
    public GameObject spawnpoint;
    private Animator PlayerAnim;
    public bool falling;
    public bool landed;
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

    
    public float CountDownTimer;
    public float CoolDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = Bobot.GetComponent<Animator>();
        
    }


    
    // Update is called once per frame
    void Update()
    {

        Vector3 movementDirection = new Vector3(player.GetComponent<ThirdMover>().DirectionHorizon, 0, player.GetComponent<ThirdMover>().DirectionVertical);

        CountDownTimer -= Time.deltaTime;
        CoolDownTimer += Time.deltaTime;

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
        if (Input.GetButton("Jump") && Grounded && canJump == true)
        {
            jumpTime += Time.deltaTime;
            velocity.y = Test.Evaluate(jumpTime);
            CoolDownTimer = 0f;



        }
        else if (Input.GetButtonUp("Jump") && Grounded )
        {

            jumpTime = 0;
            

            Debug.Log("Jump buton lifted");
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
        else if (Input.GetKeyUp(KeyCode.W) || Climbable == false && Grounded)
        {

            climbTime = 0;
            

        }

        if (velocity.y >= 20f)
        {
            velocity.y = 20f;


        }

        

        nextY = transform.position.y;

       

        if(nextY != currentY)
        {
          prevY = currentY;
            currentY = nextY;

        }

        if (Input.GetButton("Jump") && currentY > prevY && Grounded == false)
       {
            PlayerAnim.SetBool("Jumping", true);

            PlayerAnim.SetFloat("Ypos", 1f);
            CoolDownTimer = 0f;

        }

        if (transform.position.y >= -0.6f)
        {

            CountDownTimer = 1.0f;

        }

        if(CountDownTimer <= 0.5f)
        {
            characterController.enabled = false;
            characterController.transform.position = spawnpoint.transform.position;
            characterController.enabled = true;

        }

        PlayerAnim.SetBool("JumpEnd", JumpEnd);

        if (currentY < prevY && Grounded == false)
        {
            PlayerAnim.SetFloat("Ypos", -1f);
            PlayerAnim.SetBool("Jumping", false);
            JumpEnd = true;
            CoolDownTimer = 0f;
        }
       
        
        if (currentY > prevY && Climbable == true)
        {
            PlayerAnim.SetBool("Climbing", true);

        }
        else
        {
            PlayerAnim.SetBool("Climbing", false);

        }

        if ( Grounded == true)
        {

            JumpEnd = false;

            
            

        }

        if (CoolDownTimer >= 0.3f)
        {
            canJump = true;

        }
        else
        {
            
            canJump = false;
        }
       








    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + offsetpos1 + Vector3.down * offset, size);
        Gizmos.DrawWireCube(transform.position + offsetpos2 + Vector3.up * offset, size);
        Gizmos.DrawWireCube(transform.position + offsetpos3 + transform.forward * offset, sizeclimb);
    }
}
