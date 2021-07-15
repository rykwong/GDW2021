using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //speed
    //public float speed = 3f;
    [Header("Movement Variables")]
    [SerializeField] float walkSpeed = 1.5f;
    [SerializeField] float runSpeed;
    [SerializeField] float runBuildUpSpeed;
    private float movementSpeed = 0.4f;
    private bool isPlatformed;


    //jump
    [Header("Jump Variables")]
    public float jumpHeight = 3f;
    
    [Header("Physics Variables")]
    //physics
    private Vector3 velocity;
    Vector3 move;
    private float gravity = -9.18f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Push Variables")]
    public float pushPower = 2.0f;
    public float pushDistance;
    private GameObject box;
    RaycastHit hit;

    //boolean



    //boolean

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
            Push();
        }
        //Debug.Log("Movement Speed:" + movementSpeed);
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



        move = transform.right * x + transform.forward * z;




        controller.Move(move * walkSpeed * Time.deltaTime);

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
            movementSpeed = Mathf.Lerp(movementSpeed, runSpeed, Time.deltaTime * runBuildUpSpeed);
            controller.Move(move * movementSpeed * Time.deltaTime);
        }
        else
        {
            movementSpeed = Mathf.Lerp(movementSpeed, walkSpeed, Time.deltaTime * runBuildUpSpeed);
            controller.Move(move * movementSpeed * Time.deltaTime);
        }
    }


    private void Push()
    {
        Debug.DrawRay(transform.position, transform.forward * pushDistance, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, pushDistance))
        {
            if (hit.collider.gameObject.CompareTag("Pushable"))
            {
                Debug.Log(hit);
                if (Input.GetKey(KeyCode.P))
                {
                    // Debug.Log(gameObject);
                    Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(direction*pushPower);
                }
            }
        }


    }
    // void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     if (hit.transform.tag == "Pushable")
    //     {
    //         Rigidbody body = hit.collider.attachedRigidbody;
    //
    //         // no rigidbody
    //         if (body == null || body.isKinematic)
    //         {
    //             return;
    //         }
    //
    //         // We dont want to push objects below us
    //         if (hit.moveDirection.y < -0.3)
    //         {
    //             return;
    //         }
    //
    //         // Calculate push direction from move direction,
    //         // we only push objects to the sides never up and down
    //         Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
    //
    //         // If you know how fast your character is trying to move,
    //         // then you can also multiply the push velocity by that.
    //
    //         // Apply the push
    //         body.velocity = pushDir * pushPower;
    //     }
    //
    //     // if (hit.transform.CompareTag("Platform"))
    //     // {
    //     //     if (!isPlatformed)
    //     //     {
    //     //         transform.parent = hit.transform;
    //     //         isPlatformed = true;
    //     //     }
    //     //     // Debug.Log(transform.parent);
    //     // }
    //     // else
    //     // {
    //     //     if (isPlatformed)
    //     //     {
    //     //         transform.parent = null;
    //     //         isPlatformed = false;
    //     //     }
    //     //     Debug.Log("Not on Platform");
    //     // }
    // }
}
