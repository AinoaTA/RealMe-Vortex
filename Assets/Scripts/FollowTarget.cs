using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistance = 2;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _maxSpeed = 1;
    [SerializeField] private float _smooth = 0.5f;

    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        if (GameManager.instance.MustFollowPlayer)
        {
            if (Vector2.Distance(transform.position, _target.position) > _minDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _smooth, _maxSpeed, Time.deltaTime);
            }
        }
    }
}