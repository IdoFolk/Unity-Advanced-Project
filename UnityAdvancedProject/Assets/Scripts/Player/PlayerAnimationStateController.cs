using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationStateController : MonoBehaviour
{
    [FormerlySerializedAs("_animator")] [SerializeField] private Animator animator;
    [SerializeField] float acceleration = 0.1f;

    private float _velocityX;
    private float _velocityZ;

    private int _velocityXHash;
    private int _velocityZHash;
    private int _isCastingHash;

    private void Awake()
    {
        _isCastingHash = Animator.StringToHash("IsCasting");
        _velocityXHash = Animator.StringToHash("Velocity X");
        _velocityZHash = Animator.StringToHash("Velocity Z");
    }

    private void Update()
    {
        var runIsPressed = Input.GetKey(KeyCode.LeftShift);
        var fireIsPressed = Input.GetMouseButtonDown(0);
        var fireIsReleased = Input.GetMouseButtonUp(0);

        _velocityX = Input.GetAxis("Horizontal");
        _velocityZ = Input.GetAxis("Vertical");

        if (runIsPressed)
        {
            _velocityX += Mathf.Lerp(_velocityX, _velocityX * acceleration, Time.deltaTime * 0.1f);
            _velocityZ += Mathf.Lerp(_velocityZ, _velocityZ * acceleration, Time.deltaTime * 0.1f);
        }
     
        animator.SetFloat(_velocityXHash, _velocityX);
        animator.SetFloat(_velocityZHash, _velocityZ);

        if (fireIsPressed)
        {
            animator.SetTrigger(_isCastingHash);
        }

        if (fireIsReleased)
        {
            animator.ResetTrigger(_isCastingHash);
        }
    }
}
