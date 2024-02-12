using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnitSystem;
using UnityEngine;

public class PlayerCharacter : Unit, IAttacker, IDamagable
{
    [SerializeField] private StatConfig _statConfig;
    private Stats _playerStats;

    private void Start()
    {
        _playerStats = _statConfig.GenerateStats();
    }
    
    

    #region IAttacker

    public event Action<IAttacker, IDamagable> OnAttack;

    public void Attack(IDamagable target)
    {
        throw new NotImplementedException();
    }

    public Weapon CurrentWeapon { get; }


    public Stat Damage { get; set; }

    #endregion

    #region IDamagable
    
    public event Action<IDamagable> OnHit;
    public event Action<IDamagable> OnDeath;
    public float CurrentHp { get; set; }
    public void GetHit(float damage)
    {
        throw new NotImplementedException();
    }
    public void Heal(float value)
    {
        throw new NotImplementedException();
    }

    #endregion



}