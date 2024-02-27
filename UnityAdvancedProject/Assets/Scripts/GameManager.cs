using System;
using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    public static event Action OnGamePaused;
    public static event Action OnGameResumed;

    private bool _isGamePaused;

    private void Awake()
    {
        if (playerController == null)
        {
            Debug.LogError("Game Manager is missing the player controller! ABORTING Awake!");
            return;
        }

        playerController.OnPlayerPressedPause += HandleOnPlayerPressedPause;
    }

    private void OnDestroy()
    {
        if (playerController == null)
        {
            return;
        }

        playerController.OnPlayerPressedPause -= HandleOnPlayerPressedPause;
    }

    private void HandleOnPlayerPressedPause()
    {
        if (!_isGamePaused)
        {
            _isGamePaused = true;
            Debug.Log($"Game is paused!");
            OnGamePaused?.Invoke();
            return;
        }
        
        _isGamePaused = false;
        Debug.Log($"Game is resumed!");
        OnGameResumed?.Invoke();
    }
}
