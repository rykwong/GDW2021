using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //speed
    public float speed = 3f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float runSpeed;
    [SerializeField] float runBuildUpSpeed;
    private float movementSpeed;


    //jump
    public float jumpHeight = 3f;

    //physics
    private Vector3 velocity;
    private float gravity = -9.18f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
<<<<<<< HEAD
    float pushPower = 2.0f;

    //boolean
=======
   
>>>>>>> 6c37d2a27867bbdb5b217ac89fdf157c2ac4f7f3
    private bool isGrounded;
    private Transform toMove;

    //velocity
    Vector3 currentDirVelocity = Vector3.zero;
    Vector3 currentDir = Vector3.zero;


    //smooth dampener
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            Move();
            Sprint();
        }

    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 targetDirection = new Vector3(x, 0, z);
        currentDir = Vector3.SmoothDamp(currentDir, targetDirection, ref currentDirVelocity, moveSmoothTime);



        Vector3 move = transform.right * x + transform.forward * z;




        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Mathf.Lerp(speed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        }
        else
        {
            speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Pushable")
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            // no rigidbody
            if (body == null || body.isKinematic)
            {
                return;
            }

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * pushPower;
        }
    }
}
