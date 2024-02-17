using System;
using System.Collections.Generic;

namespace UnitSystem
{
    [Serializable]
    public class Stat
    {
        public event Action<float> OnStatChange;
        public readonly StatType StatType;
        public readonly float BaseValue;
        
        private List<float> modifiers = new List<float>();

        public float CurrentValue
        {
            get
            {
                float finalValue = BaseValue;
                modifiers.ForEach(mod => finalValue += mod);
                return finalValue;
            }
        }
        
        public Stat(StatConfig config)
        { 
            StatType = config.StatType;
            BaseValue = config.BaseValue;
        }
        public void AddModifier(float modifier) 
        {
            if (modifier != 0)
            {
                modifiers.Add(modifier);
                OnStatChange?.Invoke(CurrentValue);
            }
        }
        public void RemoveModifier(float modifier) 
        {
            if (modifier != 0)
            {
                modifiers.Remove(modifier);
                OnStatChange?.Invoke(CurrentValue);
            }
        }
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