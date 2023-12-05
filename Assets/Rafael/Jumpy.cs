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

    float m_MaxDistance = 1f;

   

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




        if (Input.GetButtonDown("Jump") && Physics.BoxCast(transform.position, transform.lossyScale, Vector3.down * 0.5f, Quaternion.identity, m_MaxDistance) && canJump == true)
        {

            velocity.y = jump;

        }
        else
        {

            velocity.y += Gravity * Time.deltaTime;

        }
        
            characterController.Move(velocity * Time.deltaTime);

        
    }
}
