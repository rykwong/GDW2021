using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private float gravity = -9.18f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // [Header("Push Variables")]
    // public float pushPower = 2.0f;
    // public float pushDistance;
    // RaycastHit hit;
    // private TextMeshProUGUI popup;
    private void Start()
    {
        // popup = GameObject.Find("Popup").GetComponent<TextMeshProUGUI>();
    }

    //boolean



    //boolean

    private bool isGrounded;
    private Transform toMove;
    private GameObject movement;

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
            // Push();
        }
        Debug.Log("Movement Speed:" + movementSpeed);
        Debug.LogError("I am an error through Debug.LogError");
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


    // private void Push()
    // {
    //     Debug.DrawRay(transform.position, transform.forward * pushDistance, Color.blue);
    //     if (Physics.Raycast(transform.position, transform.forward, out hit, pushDistance))
    //     {
    //         if (hit.collider.gameObject.CompareTag("Pushable"))
    //         {
    //             popup.SetText( "Press P To Push");
    //             if (Input.GetKey(KeyCode.P))
    //             {
    //                 // Debug.Log(gameObject);
    //                 Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);
    //                 hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(direction*pushPower);
    //             }
    //         }
    //         else
    //         {
    //             popup.SetText( "");
    //         }
    //     }
    //     else
    //     {
    //         popup.SetText( "");
    //     }
    // }
}
