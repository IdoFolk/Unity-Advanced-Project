using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int Damage { get; private set; }
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    public void Init(int damage)
    {
        Damage = damage;
    }

    private void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}