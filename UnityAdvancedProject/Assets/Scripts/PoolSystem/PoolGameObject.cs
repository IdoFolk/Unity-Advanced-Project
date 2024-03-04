using System;
using UnityEngine;

namespace PoolSystem
{
    public abstract class PoolGameObject : MonoBehaviour
    {
        public event Action<PoolGameObject> OnObjectCanBeCleaned;
        
        public void ResetTransform()
        {
            var myTransform = transform;
            myTransform.position = Vector3.zero;
            myTransform.rotation = Quaternion.identity;
            myTransform.localScale = Vector3.one;
        }
        
        protected virtual void OnDisable()
        {
            OnObjectCanBeCleaned?.Invoke(this);
        }
    }
}
