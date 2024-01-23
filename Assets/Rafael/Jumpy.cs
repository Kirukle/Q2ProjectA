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
    public GameObject maincamera;
    bool JumpEnd;

    float currentY;
    float nextY;
    float prevY;
    public AudioSource JumpSfx;
    public AudioSource LandSfx;
    public GameObject ClimbableWall;
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
    public Vector3 sizelow;
    public Vector3 sizehigh;
    public float offset;
    public float m_MaxDistance = 0.09f;
    public Vector3 offsetpos1;
    public Vector3 offsetpos2;
    public Vector3 offsetpos3;
    public Vector3 sizeclimb;
    public float climb_MaxDistance = 0.09f;
    RaycastHit hit;


    public LayerMask ClimbWall;

    
    public bool CanClimb;
    public bool Grounded => Physics.BoxCast(transform.position + offsetpos1, sizelow / 2, Vector3.down * offset, Quaternion.identity, m_MaxDistance);
    public bool Ceiling => Physics.BoxCast(transform.position + offsetpos2, sizehigh / 2, Vector3.up * offset, Quaternion.identity, m_MaxDistance);

    public bool Climbable => Physics.BoxCast(transform.position + offsetpos3, sizeclimb / 2, transform.forward * offset, out hit, Quaternion.identity, climb_MaxDistance, ClimbWall);

    
    public float CountDownTimer;
    public float CoolDownTimer;
    public float ClimbTimer;

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
        ClimbTimer -= Time.deltaTime;
        //float horizontal = Input.GetAxis("Horizontal") * Speed;
        //float vertical = Input.GetAxis("Vertical") * Speed;
        //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //characterController.Move(move * Speed * Time.deltaTime);


        Test.Evaluate(0.5f);
        Climb.Evaluate(0.5f);

        if (Input.GetButtonDown("Jump") && Grounded && canJump == true )
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
            JumpSfx.Play();


        }
        else if (Input.GetButtonUp("Jump") && Grounded )
        {

            jumpTime = 0;
            

            Debug.Log("Jump buton lifted");
        }
        
            characterController.Move(velocity * Time.deltaTime);
        if (Grounded)
        {
           

        }

        if (Ceiling)
        {
            velocity.y = -3;

        }

        if (Input.GetKey(KeyCode.W) && Climbable && CanClimb == true && ClimbTimer <= 0f)
        {

            climbTime += Time.deltaTime;
            velocity.y = Climb.Evaluate(climbTime);
            ClimbableWall = hit.transform.gameObject;
            maincamera.GetComponent<ThirdPerson>().distance = 20;
            

        }
        else if (Input.GetKeyUp(KeyCode.W) || Climbable == false && Grounded)
        {

            climbTime = 0;
            maincamera.GetComponent<ThirdPerson>().distance = 10;

        }
        
        //if(ClimbableWall == true && currentY < prevY)
        //{
        //    velocity.y = 0;


        //}

        if (velocity.y >= 20f)
        {
            velocity.y = 20f;


        }

        //if (velocity.y >= -20f)
        //{
        //    velocity.y = -20f;


        //}

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

        if (transform.position.y >= -27f)
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
            LandSfx.Play();
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

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "EndClimb")
        {

            velocity.y = 0;
            ClimbTimer = 1f;
        }
        else if(ClimbTimer <=0f)
        {
            return;

        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + offsetpos1 + Vector3.down * offset, sizelow);
        Gizmos.DrawWireCube(transform.position + offsetpos2 + Vector3.up * offset, sizehigh);
        Gizmos.DrawWireCube(transform.position + offsetpos3 + transform.forward * offset, sizeclimb);
    }
}
