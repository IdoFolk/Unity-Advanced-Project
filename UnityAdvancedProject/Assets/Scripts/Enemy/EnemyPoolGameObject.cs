using System;
using PoolSystem;
using UnityEngine;

namespace Enemy
{
    public class EnemyPoolGameObject : PoolGameObject
    {
        [SerializeField] private EnemyAIController controller;

        private void OnValidate()
        {
            controller ??= GetComponent<EnemyAIController>();
        }

        public void Init(Vector3 pos)
        {
            gameObject.SetActive(true);
            controller.Init(pos);
        }
    }
}
