using DefaultNamespace;
using UnityEngine;

namespace UnitSystem
{
    [CreateAssetMenu(menuName = "PlayerConfig",fileName = "NewPlayerConfig",order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private StatConfig _statConfig;
        [SerializeField] private Weapon _startingWeapon;
    }
}