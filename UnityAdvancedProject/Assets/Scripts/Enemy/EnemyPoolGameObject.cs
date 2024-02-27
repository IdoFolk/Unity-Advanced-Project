using PoolSystem;

namespace Enemy
{
    public class EnemyPoolGameObject : PoolGameObject
    {
        // TODO remove, for testing
        private void Start()
        {
            Destroy(gameObject, 5);
        }
    }
}
