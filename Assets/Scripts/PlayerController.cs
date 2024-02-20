using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float speed = 10.0f;
    private float jumpForce = 10.0f;

    private float xBound = 7.0f;
    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(horizontalInput * speed * Vector3.right, ForceMode.Impulse);

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(jumpForce * playerRb.mass * Vector3.up, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
