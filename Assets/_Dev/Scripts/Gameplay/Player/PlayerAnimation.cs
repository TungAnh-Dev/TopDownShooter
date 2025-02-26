using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerInput playerInput;

    private const string SPEED_PARAM = "moveSpeed";

    [SerializeField] private float accelerationTime = 1.0f;
    [SerializeField] private float decelerationTime = 0.5f;

    private float currentSpeed = 0f;

    public float CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }

    private void Awake()
    {
        this.playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        this.UpdateAnimationBlend();
    }

    private void UpdateAnimationBlend()
    {
        if (this.playerInput.InputVector.magnitude > 0.1f)
        {
            this.currentSpeed += Time.deltaTime / this.accelerationTime;
        }
        else
        {
            this.currentSpeed -= Time.deltaTime / this.decelerationTime;
        }

        this.currentSpeed = Mathf.Clamp01(this.currentSpeed);
        this.animator.SetFloat(SPEED_PARAM, this.currentSpeed);
    }
}
