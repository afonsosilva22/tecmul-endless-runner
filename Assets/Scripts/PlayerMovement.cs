using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 4f;
    public float speedBoost = 4f;
    public float speedIncreaseRate = 0.1f;

    public float horizontalSpeed = 5;

    public float jumpForce = 6;
    public float jumpBoost = 6f;

    public float shieldDuration = 10f;
    private bool hasShield = false;

    public float leftBoundary = -6f;
    public float rightBoundary = 6f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Animator animator;

    private Coroutine speedCoroutine;
    private Coroutine jumpCoroutine;
    private Coroutine shieldCoroutine;

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

        playerSpeed += speedIncreaseRate * Time.deltaTime;
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
                    if (hasShield)
                    {
                        Destroy(collision.gameObject);
                        hasShield = false;

                        if (shieldCoroutine != null)
                        {
                            StopCoroutine(shieldCoroutine);
                        }

                        Debug.Log("Shield used!");
                        return;
                    }
                    else
                    {
                    GameOverMenu.instance.ShowGameOver();
                    }
                }
            }
        }
    }

    public void ActivateSpeedBoost(float duration)
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        speedCoroutine = StartCoroutine(SpeedBoost(duration));
    }

    IEnumerator SpeedBoost(float duration)
    {
        playerSpeed += speedBoost;

        yield return new WaitForSeconds(duration);

        playerSpeed -= speedBoost;
    }

    public void ActivateJumpBoost(float duration)
    {
        if (jumpCoroutine != null)
        {
            StopCoroutine(jumpCoroutine);
        }
    
        jumpCoroutine = StartCoroutine(JumpBoost(duration));
    }

    IEnumerator JumpBoost(float duration)
    {
        jumpForce += jumpBoost;

        yield return new WaitForSeconds(duration);

        jumpForce -= jumpBoost;
    }

    public void ActivateShield(float duration)
    {   
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }

        shieldCoroutine = StartCoroutine(Shield(duration));
    }

    IEnumerator Shield(float duration)
    {
        hasShield = true;

        yield return new WaitForSeconds(duration);

        hasShield = false;
    }
}