using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 _lunchDirection = new Vector3(1f, 7f, 0f);
    private IPlatformMovable _platformMovable;

    private BallMove _ball;
    private void Start()
    {
        _platformMovable = GetComponent<IPlatformMovable>();
    }

    private void FixedUpdate()
    {
        _platformMovable.Move();

        if (transform.childCount > 1 && Input.GetKeyDown(KeyCode.Space))
        {
            BallMove ball = transform.GetComponentInChildren<BallMove>();

            ball.Launch(_lunchDirection);
        }
    }
}
