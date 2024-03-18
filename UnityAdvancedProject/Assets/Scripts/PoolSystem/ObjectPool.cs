using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : PoolGameObject
    {
        private readonly List<T> _totalPool = new();
        private readonly List<int> _readyObjectsIndices = new();

        protected void InitPool(int initialPoolSize, T objectPrefab, Transform parentTransform = null)
        {
            CreateNewObjectsAndAddToPool(initialPoolSize, objectPrefab, parentTransform);
        }

        public T GetReadyObject()
        {
            if (_readyObjectsIndices.Count == 0)
            {
                // todo create X new objects, and add it to the pool
                Debug.LogError($"Pool is empty!!");
                return null;
            }

            var readyObjectIndex = _readyObjectsIndices[0];
            _readyObjectsIndices.RemoveAt(0);
            
            var objectToPull = _totalPool[readyObjectIndex];
            return objectToPull;
        }
        
        private void ClearObject(PoolGameObject poolGameObjectToClear)
        {
            var typedObject = poolGameObjectToClear as T;
            if (!_totalPool.Contains(typedObject))
            {
                if (typedObject != null)
                    Debug.LogError($"Trying to clear {typedObject.name} from the pool but it cannot be found!");
                return;
            }
            
            ResetObject(typedObject);

            var indexInPool = _totalPool.IndexOf(typedObject);
            _readyObjectsIndices.Remove(indexInPool);
        }

        private static void ResetObject(PoolGameObject poolGameObjectToClear)
        {
            poolGameObjectToClear.ResetTransform();
            poolGameObjectToClear.gameObject.SetActive(false);
        }

        private void CreateNewObjectsAndAddToPool(int initialPoolSize, T objectPrefab, Transform parentTransform)
        {
            for (var i = 0; i < initialPoolSize; i++)
            {
                var parent = parentTransform ??= transform;
                var newObject = Instantiate(objectPrefab, parent);
                
                ResetObject(newObject);

                newObject.OnObjectCanBeCleaned += ClearObject;
                
                _totalPool.Add(newObject);
                _readyObjectsIndices.Add(i);
            }
        }
    }
}
