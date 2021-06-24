using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float jumpHeight = 3f;
    private Vector3 velocity;
    private float gravity = -20f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject[] objects;
    public int maxMaterials = 100;
    public float spawnDistance = 5f;
    public int spawnCost = 10;

    private int materials;
    private bool isGrounded;
    private Transform toMove;

    // Update is called once per frame
    void Update()
    {
        Move();
        SpawnObj();
    }

    private void SpawnObj()
    {
        if (Input.GetButtonDown("1Key") && materials + spawnCost < maxMaterials)
        {
            Vector3 spawnPos = controller.transform.position + controller.transform.forward * spawnDistance;
            Instantiate(objects[0], spawnPos, controller.transform.rotation);
            materials += spawnCost;
        }else if (Input.GetButtonDown("2Key") && materials + spawnCost < maxMaterials)
        {
            Vector3 spawnPos = controller.transform.position + controller.transform.forward * spawnDistance;
            Instantiate(objects[1], spawnPos, controller.transform.rotation);
            materials += spawnCost;
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
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    float pushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
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
