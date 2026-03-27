using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 4;
    public float horizontalSpeed = 5;
    public float jumpForce = 6;
    public float leftBoundary = -6f;
    public float rightBoundary = 6f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > leftBoundary)
            {
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < rightBoundary)
            {
                transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.normal.y < 0.5f)
                {
                    Debug.Log("Game Over!");
                    Time.timeScale = 0;
                }
            }
        }
    }
}
