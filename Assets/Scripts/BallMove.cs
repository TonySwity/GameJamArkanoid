using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private Rigidbody _rigidbody;

    private Vector3 _position;
    private Vector3 _currentVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction)
    {
        transform.parent = null;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = direction.normalized * _speed;

    }

    public void Catch(Transform parent)
    {
        transform.parent = parent;
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector3.zero;
    }

}
