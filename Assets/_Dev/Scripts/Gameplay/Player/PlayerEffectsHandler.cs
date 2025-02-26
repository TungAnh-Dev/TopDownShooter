using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerEffectsHandler : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    
    [SerializeField] private ParticleSystem runFX;

    private void Awake()
    {
        this.playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void LateUpdate()
    {
        float currentSpeed = this.playerAnimation.CurrentSpeed;

        this.UpdateRunFX(currentSpeed);
    }

    private void UpdateRunFX(float speed)
    {
        bool isRunning = speed >= 0.85f;

        if (isRunning && !this.runFX.isPlaying)
        {
            this.runFX.Play();
        }
        else if (!isRunning && this.runFX.isPlaying)
        {
            this.runFX.Stop();
        }
    }
}
