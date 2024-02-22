using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float speed = 5f;

        private Vector3 _moveToMakeOnNextTick;

        private bool _isGamePaused;

        private void OnValidate()
        {
            playerController ??= GetComponent<PlayerController>();
        }

        private void Awake()
        {
            GameManager.OnGamePaused += HandleOnGamePaused;
            GameManager.OnGameResumed += HandleOnGameResumed;
            
            playerController.OnPlayerMoving += HandlePlayerMovement;
        }

        private void FixedUpdate()
        {
            if (_isGamePaused)
            {
                return;
            }
            
            transform.position += _moveToMakeOnNextTick * Time.fixedDeltaTime;
        }

        private void OnDestroy()
        {
            GameManager.OnGamePaused -= HandleOnGamePaused;
            GameManager.OnGameResumed -= HandleOnGameResumed;
            
            playerController.OnPlayerMoving -= HandlePlayerMovement;
        }

        private void HandlePlayerMovement(Vector2 move)
        {
            var finalMove = new Vector3(move.x, 0, move.y) * speed;
            _moveToMakeOnNextTick = finalMove;
        }
        
        private void HandleOnGameResumed()
        {
            _isGamePaused = false;
        }

        private void HandleOnGamePaused()
        {
            _isGamePaused = true;
        }
    }
}
