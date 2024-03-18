using PoolSystem;
using UnityEngine;

namespace Enemy
{
    public class EnemyPool : ObjectPool<EnemyPoolGameObject>
    {
        [SerializeField] private EnemyPoolGameObject enemyPrefab;

        [SerializeField] private int poolSize = 50;
        void Awake()
        {
            if (enemyPrefab == null)
            {
                Debug.LogError($"{name} is missing an enemy prefab! Aborting pool init.");
                return;
            }
            InitPool(poolSize, enemyPrefab, transform);
        }
    }
}
