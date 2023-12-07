using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 velocity;
    public float Speed = 2f;
    public float jump = 10f;
    public float Gravity = -9.8f;
    public bool canJump;

    public AnimationCurve Test;
    public float jumpTime;

    [Header("Boxcast Settings")]
    public Vector3 size;
    public float offset;
    public float m_MaxDistance = 0.09f;

    public bool Grounded => Physics.BoxCast(transform.position, size / 2, Vector3.down * offset, Quaternion.identity, m_MaxDistance);


   

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal") * Speed;
        //float vertical = Input.GetAxis("Vertical") * Speed;
        //Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //characterController.Move(move * Speed * Time.deltaTime);


        Test.Evaluate(0.5f);

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
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down * offset, size);
    }
}
