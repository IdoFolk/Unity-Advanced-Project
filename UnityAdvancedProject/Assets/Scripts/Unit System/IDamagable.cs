using System;
using UnityEngine;

namespace UnitSystem
{
    public interface IDamagable
    {
        public event Action<IDamagable> OnHit;
        public event Action<IDamagable> OnDeath;
        public float CurrentHp { get; set; }
        public void GetHit(float damage);
        public void Heal(float value);
    }
}