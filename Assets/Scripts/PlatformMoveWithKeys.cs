using UnityEngine;

namespace Gameplay.Platform
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformMoveWithKeys: MonoBehaviour, IPlatformMovable
    {
        [SerializeField] private float _speed = 10f;
        
        private Rigidbody _rigidbody;
        private float _horizontalInput;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        public void Move(){
    
            _rigidbody.velocity = Vector3.right * (_speed * _horizontalInput); 
        }
    }
}
