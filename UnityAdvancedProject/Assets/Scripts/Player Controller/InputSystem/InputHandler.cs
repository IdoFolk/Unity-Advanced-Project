using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    public event Action<bool> Aim;
    public event Action<bool> Shoot;
    [Header("Character Input Values")] 
    public Vector2 MoveValue;
    public Vector2 LookValue;
    public bool JumpValue;
    public bool SprintValue;
    public bool AimValue;
    public bool ShootValue;

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
        Aim?.Invoke(value.performed);
    }
    public void OnShoot(InputAction.CallbackContext value)
    {
        ShootInput(value.performed);
        Shoot?.Invoke(value.performed);
    }
    #endregion

    #region InputValues
    public void MoveInput(Vector2 newMoveDirection)
    {
        MoveValue = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        LookValue = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        JumpValue = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        SprintValue = newSprintState;
    }
    public void AimInput(bool newAimState)
    {
        AimValue = newAimState;
    }
    public void ShootInput(bool newShootState)
    {
        ShootValue = newShootState;
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