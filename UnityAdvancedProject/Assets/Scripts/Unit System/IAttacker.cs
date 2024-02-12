using System;
using DefaultNamespace;

namespace UnitSystem
{
    public interface IAttacker
    {
        public event Action<IAttacker,IDamagable> OnAttack;
        public void Attack(IDamagable target);
        
        public Weapon CurrentWeapon { get; }
        public Stat Damage { get; }
    }
}