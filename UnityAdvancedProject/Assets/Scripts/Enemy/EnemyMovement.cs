using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        private void OnValidate()
        {
            navMeshAgent ??= GetComponent<NavMeshAgent>();
        }
    }
}
