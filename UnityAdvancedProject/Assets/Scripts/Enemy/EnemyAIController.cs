using UnityEngine;

namespace Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        public void Init(Vector3 pos)
        {
            transform.position = pos;
        }
    }
}
