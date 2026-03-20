using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 4;
    public float horizontalSpeed = 5;
    public float jumpForce = 7;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}
