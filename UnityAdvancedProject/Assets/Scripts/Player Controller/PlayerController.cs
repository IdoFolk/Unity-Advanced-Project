using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform castPos;

    private ThirdPersonController _thirdPersonController;
    private InputHandler _inputHandler;

    private void OnValidate()
    {
        _inputHandler ??= GetComponent<InputHandler>();
        _thirdPersonController ??= GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        _inputHandler.Aim += AimCamera;
        _inputHandler.Shoot += ShootProjectile;
    }

    private void Update()
    {
        Vector3 mouseWorldPos = Vector3.zero;
        var screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        var ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderLayerMask))
        {
            mouseWorldPos = hit.point;
        }

        if (_inputHandler.AimValue)
        {
            var worldAimTarget = mouseWorldPos;
            var position = transform.position;
            worldAimTarget.y = position.y;
            var aimDirection = (worldAimTarget - position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20);
        }

        if (_inputHandler.ShootValue)
        {
            var aimDir = (mouseWorldPos - castPos.position).normalized;
            var projectile = Instantiate(projectilePrefab,castPos.position,Quaternion.LookRotation(aimDir));
            _inputHandler.ShootValue = false;
        }
    }

    private void ShootProjectile(bool isPressed) //temp
    {
    }

    private void AimCamera(bool isPressed)
    {
        aimVirtualCamera.gameObject.SetActive(isPressed);
        _thirdPersonController.SetSensitivity(isPressed ? aimSensitivity : normalSensitivity);
        _thirdPersonController.SetRotateOnMove(!isPressed);
    }
}