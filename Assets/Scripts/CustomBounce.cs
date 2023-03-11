using UnityEngine;

public class CustomBounce : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            float boundX =transform.GetComponentInChildren<BoxCollider>().bounds.extents.x * 2f;
            float relativePosition = (collision.transform.position.x - transform.position.x) / boundX;
            Debug.Log(relativePosition);
            collision.rigidbody.velocity = new Vector3(relativePosition, 1f, 0f).normalized * collision.rigidbody.velocity.magnitude;
        }
    }

}
