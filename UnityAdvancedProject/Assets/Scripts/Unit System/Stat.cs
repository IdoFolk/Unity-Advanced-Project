using System;

namespace UnitSystem
{
    [Serializable]
    public struct Stat
    {
        public StatType StatType;
        public float Value;
    }

    public enum StatType
    {
        MaxHp,
        Damage,
        MoveSpeed,
        Armor,
        AttackSpeed,
        
    }
}