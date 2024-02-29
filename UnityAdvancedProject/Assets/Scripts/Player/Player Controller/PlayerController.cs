using System;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;
    [SerializeField] private Transform debugTransform;

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

    private void ShootProjectile(bool isPressed) //temp
    {
        var screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        var ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = hit.point;
        }
    }

    private void AimCamera(bool isPressed)
    {
        aimVirtualCamera.gameObject.SetActive(isPressed);
        _thirdPersonController.SetSensitivity(isPressed ? aimSensitivity : normalSensitivity);
    }
}