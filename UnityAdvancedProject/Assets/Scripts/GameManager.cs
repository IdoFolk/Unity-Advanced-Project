using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGamePaused;
    public static event Action OnGameResumed;

    private bool _isGamePaused;
}
