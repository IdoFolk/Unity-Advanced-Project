using System;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;

        private void Start()
        {
            if (enemyPool == null)
            {
                Debug.LogError($"Enemy spawner '{name}' is missing an enemy pool to draw from!");
                return;
            }
            
            SpawnNewEnemy();
        }

        private void SpawnNewEnemy()
        {
            var pos = transform.position; // TODO change to random position within spawner radius
            var newEnemy = enemyPool.GetReadyObject();
            newEnemy.Init(pos);
        }
    }
}
