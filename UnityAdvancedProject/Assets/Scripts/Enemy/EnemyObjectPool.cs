using PoolSystem;
using UnityEngine;

namespace Enemy
{
    public class EnemyObjectPool : ObjectPool<EnemyPoolGameObject>
    {
        [SerializeField] private EnemyPoolGameObject enemyPrefab;

        [SerializeField] private int poolSize = 50;
        // Start is called before the first frame update
        void Start()
        {
            InitPool(poolSize, enemyPrefab, transform);
        }
    }
}
