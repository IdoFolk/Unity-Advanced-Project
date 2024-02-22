using UnityEngine;

namespace Player
{
    public class PlayerAimHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer = 1;

        void Update()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (!Physics.Raycast(ray, out hitInfo, Mathf.Infinity, groundLayer.value))
                return;

            if (Vector3.Distance(hitInfo.point, transform.position) < 1f)
            {
                return;
            }

            var lookPosition = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);

            transform.LookAt(lookPosition);
        }
    }
}