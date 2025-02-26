using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 700f;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 inputDirection = playerInput.InputVector;

        if (inputDirection.magnitude > 0f)
        {
            Vector3 movement = inputDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);

            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
