using UnitSystem;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Weapon",fileName = "NewWeapon",order = 1)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private Stat Damage;
        [SerializeField] private Stat AttackSpeed;
        
    }
}