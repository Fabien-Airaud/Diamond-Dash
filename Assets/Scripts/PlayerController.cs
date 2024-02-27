using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 10.0f;
    private readonly float jumpForce = 10.0f;

    private readonly float xBound = 5.0f;
    private bool isGrounded = true;

    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }


    // Move the player left and right and can jump
    private void MovePlayer()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        if (isGrounded) playerRb.AddForce(horizontalInput * speed * Vector3.right, ForceMode.Impulse);
        else playerRb.AddForce(0.2f * horizontalInput * speed * Vector3.right, ForceMode.Impulse);

        // Jumping
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            playerRb.AddForce(jumpForce * playerRb.mass * Vector3.up, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Constrain the player position to the screen
    private void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player has collided with " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Player has collided with " + other.gameObject.name);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Diamond"))
        {
            Debug.Log("Player has collided with " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
