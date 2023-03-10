using UnityEngine;

namespace Gameplay.Ball
{
    public class Ball: MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(@$"{collision.gameObject.name} {collision.contacts[0].normal}");
        }
    }
}
