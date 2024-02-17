using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;


namespace UnitSystem
{
    [Serializable]
    public struct StatSheetConfig
    {
        [SerializeField] private StatConfig _maxHp;
        [SerializeField] private StatConfig _damage;
        [SerializeField] private StatConfig _moveSpeed;
        [SerializeField] private StatConfig _armor;
        [SerializeField] private StatConfig _attackSpeed;

        public StatConfig MaxHp => _maxHp;
        public StatConfig Damage => _damage;
        public StatConfig MoveSpeed => _moveSpeed;
        public StatConfig Armor => _armor;
        public StatConfig AttackSpeed => _attackSpeed;
    }
    
    [Serializable]
    public struct StatConfig
    {
        [SerializeField] private StatType _statType;
        [SerializeField] private float _baseValue;

        public StatType StatType => _statType;
        public float BaseValue => _baseValue;
    }
}