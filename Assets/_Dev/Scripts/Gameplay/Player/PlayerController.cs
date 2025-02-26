using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody), typeof(PlayerAnimation))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    private PlayerAnimation playerAnimation;

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float rotationSpeed = 700f;

    private void Awake()
    {
        this.playerInput = GetComponent<PlayerInput>();
        this.rb = GetComponent<Rigidbody>();
        this.playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        this.MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 inputDirection = this.playerInput.InputVector;

        if (inputDirection.magnitude > 0f)
        {
            float moveSpeed = this.playerAnimation.CurrentSpeed >= 0.5f ? this.runSpeed : this.walkSpeed;

            Vector3 movement = inputDirection * moveSpeed * Time.fixedDeltaTime;
            this.rb.MovePosition(this.rb.position + movement);

            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            this.rb.rotation = Quaternion.RotateTowards(this.rb.rotation, targetRotation, this.rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
