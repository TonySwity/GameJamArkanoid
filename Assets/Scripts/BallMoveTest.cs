using UnityEngine;

public class BallMoveTest : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(7f, 0f, 8f);
    }
}
