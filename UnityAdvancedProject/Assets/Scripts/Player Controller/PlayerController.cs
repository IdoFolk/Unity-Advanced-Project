using System;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    private ThirdPersonController _thirdPersonController;
    private InputHandler _inputHandler;

    private void OnValidate()
    {
        _inputHandler ??= GetComponent<InputHandler>();
        _thirdPersonController ??= GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        _inputHandler.OnAimEvent += AimCamera;
    }

    private void AimCamera(bool isAimPressed)
    {
        aimVirtualCamera.gameObject.SetActive(isAimPressed);
        _thirdPersonController.SetSensitivity(isAimPressed ? aimSensitivity : normalSensitivity);
    }
}