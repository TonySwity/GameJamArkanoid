using UnityEngine;

namespace Gameplay.Platform
{
    public class PlatformMoveWithMouse: MonoBehaviour, IPlatformMovable
    {
        [SerializeField] private Camera _camera;

        private float _platformPositionY;

        private void Start()
        {
            _platformPositionY = transform.position.y;
        }


        public void Move()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.back, Vector3.zero);
            plane.Raycast(ray, out float distance);
            Vector3 point = ray.GetPoint(distance);
            transform.position = new Vector3(point.x, _platformPositionY, 0f);
        }
    }
}
