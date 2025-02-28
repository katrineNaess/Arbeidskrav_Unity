using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3.5f;

    public Transform groundCheck;
    public float groundDistance = 1.5f; 
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Sikrer at spilleren lander korrekt
        if (isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -0.1f; // Hindrer "flyting"
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Flytt spilleren
        controller.Move(move * speed * Time.deltaTime);

        // Hoppelogikk
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Påfør tyngdekraft når spilleren er i lufta
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(new Vector3(0, velocity.y, 0) * Time.deltaTime);
    }
}