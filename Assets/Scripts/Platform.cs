using UnityEngine;

namespace Gameplay.Platform
{
    public class Platform: MonoBehaviour
    {
        private IPlatformMovable _platformMovable;
        private void Start()
        {
            _platformMovable = GetComponent<IPlatformMovable>();
        }

        private void Update()
        {
            _platformMovable.Move();
        }
    }
}
