using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        public InputHandler _inputHandler;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            _inputHandler.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            _inputHandler.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            _inputHandler.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            _inputHandler.SprintInput(virtualSprintState);
        }
        
    }

}
