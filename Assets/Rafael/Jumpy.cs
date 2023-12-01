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
    public bool isGrounded;

    float m_MaxDistance;

    bool m_HitDetect;

    Collider m_collider;
    RaycastHit m_Hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {

        m_HitDetect = Physics.BoxCast(m_collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);

        if (m_HitDetect)
        {

            Debug.Log("Hit" + m_Hit.collider.name);

        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * Speed * Time.deltaTime);


        

        if(Input.GetButtonDown("Jump") && transform.position.y< 0.12f)
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
