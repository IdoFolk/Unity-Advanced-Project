using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private float speed = 5f;

        private Vector3 _moveToMakeOnNextTick;

        private void OnValidate()
        {
            playerController ??= GetComponent<PlayerController>();
        }

        private void Awake()
        {
            playerController.OnPlayerMoving += HandlePlayerMovement;
        }

        private void FixedUpdate()
        {
            transform.position += _moveToMakeOnNextTick * Time.fixedDeltaTime;
        }

        private void OnDestroy()
        {
            playerController.OnPlayerMoving -= HandlePlayerMovement;
        }

        private void HandlePlayerMovement(Vector2 move)
        {
            var finalMove = new Vector3(move.x, 0, move.y) * speed;
            _moveToMakeOnNextTick = finalMove;
        }
    }
}
