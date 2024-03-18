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

        public void MoveTo(Vector3 pos)
        {
            if (navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = false;
            }
            navMeshAgent.SetDestination(pos);
        }
    }
}
