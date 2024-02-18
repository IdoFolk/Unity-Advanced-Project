using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float walkingSpeed = 2.5f;
    [SerializeField] float runningSpeed = 6f;

    float velocityX = 0.0f;
    float velocityZ = 0.0f;

    int VelocityXHash;
    int VelocityZHash;
    int isCastingHash;

    private void Start()
    {
        isCastingHash = Animator.StringToHash("IsCasting");
        VelocityXHash = Animator.StringToHash("Velocity X");
        VelocityZHash = Animator.StringToHash("Velocity Z");
    }

    private void Update()
    {
        bool runIsPressed = Input.GetKey(KeyCode.LeftShift);
        bool fireIsPressed = Input.GetKeyDown(KeyCode.Space);
        bool fireIsReleased = Input.GetKeyUp(KeyCode.Space);

        velocityX = Input.GetAxis("Horizontal");
        velocityZ = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(velocityX, 0, velocityZ);

        movment.Normalize();

        if (runIsPressed)
        {
            velocityX += Mathf.Lerp(velocityX, velocityX * acceleration, Time.deltaTime * 0.1f);
            velocityZ += Mathf.Lerp(velocityZ, velocityZ * acceleration, Time.deltaTime * 0.1f);
        }
     
        _animator.SetFloat(VelocityXHash, velocityX);
        _animator.SetFloat(VelocityZHash, velocityZ);

        if (runIsPressed)
        {
            transform.position += movment * runningSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += movment * walkingSpeed * Time.deltaTime ;
        }

        if (fireIsPressed)
        {
            _animator.SetTrigger(isCastingHash);
        }

        if (fireIsReleased)
        {
            _animator.ResetTrigger(isCastingHash);
        }
    }
}
