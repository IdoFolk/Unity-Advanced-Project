using System;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;

    private int _velocityXHash;
    private int _velocityZHash;
    private int _isCastingHash;

    private void OnValidate()
    {
        playerController ??= GetComponent<PlayerController>();
    }

    private void Awake()
    {
        _isCastingHash = Animator.StringToHash("IsCasting");
        _velocityXHash = Animator.StringToHash("Velocity X");
        _velocityZHash = Animator.StringToHash("Velocity Z");

        playerController.OnPlayerMoving += HandleOnPlayerMoving;
        playerController.OnPlayerFirePressed += HandleOnPlayerFirePressed;
        playerController.OnPlayerFireReleased += HandleOnPlayerFireReleased;
    }

    private void OnDestroy()
    {
        playerController.OnPlayerMoving -= HandleOnPlayerMoving;
        playerController.OnPlayerFirePressed -= HandleOnPlayerFirePressed;
        playerController.OnPlayerFireReleased -= HandleOnPlayerFireReleased;
    }

    private void HandleOnPlayerFireReleased()
    {
        animator.ResetTrigger(_isCastingHash);
    }

    private void HandleOnPlayerFirePressed()
    {
        animator.SetTrigger(_isCastingHash);
    }

    private void HandleOnPlayerMoving(Vector2 velocity)
    {
        animator.SetFloat(_velocityXHash, velocity.x);
        animator.SetFloat(_velocityZHash, velocity.y);
    }
}
