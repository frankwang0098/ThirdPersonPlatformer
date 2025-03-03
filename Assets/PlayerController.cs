using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveSpeedAir = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform cameraTransform;

    private bool isGrounded = true;
    private int jumpCount = 0;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * (fallMultiplier - 1) * rb.mass);
        }
    }
    public void MovePlayer(Vector2 movementInput)
    {
        float currentMoveSpeed = isGrounded ? moveSpeed : moveSpeedAir;

        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 moveDirection = (forward * movementInput.y + right * movementInput.x); ;
        rb.AddForce(currentMoveSpeed * moveDirection);
    }

    public void JumpPlayer()
    {
        if (isGrounded)
        {
            jumpCount++;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
