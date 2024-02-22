using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float RunningSpeedMultiplier = 2;
    
    [SerializeField] private float runningAccelerationMultiplier = 1.5f;

    public event Action<Vector2> OnPlayerMoving;
    
    public event Action OnPlayerFirePressed;
    public event Action OnPlayerFireReleased;

    private float _runningLerp;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPlayerFirePressed?.Invoke();
        } 
        else if (Input.GetMouseButtonUp(0))
        {
            OnPlayerFireReleased?.Invoke();
        }
        
        var velocityX = Input.GetAxis("Horizontal"); 
        var velocityZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _runningLerp += Time.deltaTime * runningAccelerationMultiplier;
            velocityX = Mathf.Lerp(velocityX, velocityX * RunningSpeedMultiplier, _runningLerp);
            velocityZ = Mathf.Lerp(velocityZ, velocityZ * RunningSpeedMultiplier, _runningLerp);
        }
        else
        {
            _runningLerp = 0;
        }
        
        OnPlayerMoving?.Invoke(new Vector2(velocityX, velocityZ));
    }
}
