using DefaultNamespace;
using UnitSystem;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerConfig", fileName = "NewPlayerConfig", order = 1)]
public class PlayerConfig : UnitConfig
{
    [SerializeField] private StatSheetConfig _statSheetConfig;
    [SerializeField] private Weapon _startingWeapon;
}