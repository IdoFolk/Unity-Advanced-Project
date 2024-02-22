using UnityEngine;

namespace Player
{
    public class PlayerAnimationStateController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Animator animator;

        private int _velocityXHash;
        private int _velocityZHash;
        private int _isCastingHash;
        
        private bool _isGamePaused;

        private void OnValidate()
        {
            playerController ??= GetComponent<PlayerController>();
        }

        private void Awake()
        {
            GameManager.OnGamePaused += HandleOnGamePaused;
            GameManager.OnGameResumed += HandleOnGameResumed;
            
            _isCastingHash = Animator.StringToHash("IsCasting");
            _velocityXHash = Animator.StringToHash("Velocity X");
            _velocityZHash = Animator.StringToHash("Velocity Z");

            playerController.OnPlayerMoving += HandleOnPlayerMoving;
            playerController.OnPlayerFirePressed += HandleOnPlayerFirePressed;
            playerController.OnPlayerFireReleased += HandleOnPlayerFireReleased;
        }

        private void OnDestroy()
        {
            GameManager.OnGamePaused -= HandleOnGamePaused;
            GameManager.OnGameResumed -= HandleOnGameResumed;
            
            playerController.OnPlayerMoving -= HandleOnPlayerMoving;
            playerController.OnPlayerFirePressed -= HandleOnPlayerFirePressed;
            playerController.OnPlayerFireReleased -= HandleOnPlayerFireReleased;
        }

        private void HandleOnPlayerFireReleased()
        {
            if (_isGamePaused)
            {
                return;
            }
            animator.ResetTrigger(_isCastingHash);
        }

        private void HandleOnPlayerFirePressed()
        {
            if (_isGamePaused)
            {
                return;
            }
            animator.SetTrigger(_isCastingHash);
        }

        private void HandleOnPlayerMoving(Vector2 velocity)
        {
            if (_isGamePaused)
            {
                return;
            }
            animator.SetFloat(_velocityXHash, velocity.x);
            animator.SetFloat(_velocityZHash, velocity.y);
        }
        
        private void HandleOnGameResumed()
        {
            _isGamePaused = false;
        }

        private void HandleOnGamePaused()
        {
            _isGamePaused = true;
            ResetAnimationStates();
        }

        private void ResetAnimationStates()
        {
            animator.SetFloat(_velocityXHash, 0);
            animator.SetFloat(_velocityZHash, 0);
            animator.ResetTrigger(_isCastingHash);
        }
    }
}
