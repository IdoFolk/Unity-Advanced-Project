using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [SerializeField] private EnemyMovement enemyMovement;

        private void OnValidate()
        {
            enemyMovement ??= GetComponent<EnemyMovement>();
        }

        public void Init(Vector3 pos)
        {
            transform.position = pos;

            enemyMovement.MoveTo(Vector3.zero);
        }
    }
}
