using System;
using UnityEngine;

namespace Gameplay.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMove : MonoBehaviour
    {
        [SerializeField] private Vector2 _startVelocity = new Vector2(7f, 8f);

        private Rigidbody _rigidbody;

        private Vector3 _position;
        private Vector3 _currentVelocity;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            StartNewGame();
        }

        public void Move()
        {
            _rigidbody.MovePosition(_rigidbody.position + _currentVelocity * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        public void StartNewGame ()
        {
            _currentVelocity = new Vector3(_startVelocity.x, _startVelocity.y, 0f);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.contacts[0].normal == Vector3.left || collision.contacts[0].normal == Vector3.right)
            {
                _currentVelocity.x *= -1;
            }
            if (collision.contacts[0].normal == Vector3.down || collision.contacts[0].normal == Vector3.up)
            {
                _currentVelocity.y *= -1;
            }

        }
    }
}
