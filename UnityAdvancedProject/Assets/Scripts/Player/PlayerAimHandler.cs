using UnityEngine;

namespace Player
{
    public class PlayerAimHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer = 1;
        
        private bool _isGamePaused;
        
        private void Awake()
        {
            GameManager.OnGamePaused += HandleOnGamePaused;
            GameManager.OnGameResumed += HandleOnGameResumed;
        }

        void Update()
        {
            if (_isGamePaused)
            {
                return;
            }
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayer.value))
                return;

            if (Vector3.Distance(hitInfo.point, transform.position) < 1f)
            {
                return;
            }

            var lookPosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);

            transform.LookAt(lookPosition);
        }
        
        private void OnDestroy()
        {
            GameManager.OnGamePaused -= HandleOnGamePaused;
            GameManager.OnGameResumed -= HandleOnGameResumed;
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