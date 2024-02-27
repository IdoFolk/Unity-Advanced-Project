using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    public event Action<bool> OnAimEvent;
    [Header("Character Input Values")] 
    public Vector2 Move;
    public Vector2 Look;
    public bool Jump;
    public bool Sprint;
    public bool Aim;

    [Header("Movement Settings")] public bool analogMovement;

    [Header("Mouse Cursor Settings")] public bool cursorLocked = true;

    #region UnityEvents

    public void OnMove(InputAction.CallbackContext value)
    {
        MoveInput(value.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        LookInput(value.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        JumpInput(value.performed);
    }

    public void OnSprint(InputAction.CallbackContext value)
    {
        SprintInput(value.performed);
    }

    public void OnAim(InputAction.CallbackContext value)
    {
        AimInput(value.performed);
        OnAimEvent?.Invoke(value.performed);
    }
    #endregion

    #region InputValues
    public void MoveInput(Vector2 newMoveDirection)
    {
        Move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        Look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        Jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        Sprint = newSprintState;
    }

    public void AimInput(bool newAimState)
    {
        Aim = newAimState;
    }
    #endregion
    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}