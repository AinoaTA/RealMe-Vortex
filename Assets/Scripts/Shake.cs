using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private Transform _toShake;
    [SerializeField] private Vector2 _xSoftMovement, _ySoftMovement;
    [SerializeField] private float _time = 0.25f;
    [SerializeField] private int _iterations = 3;

    public void DefaultShakeIt() 
    {
        CodeAnimation.Animate(_toShake, _time, CodeAnimation.CurveType.SOFT_LOOP, x: _toShake.position.x + Random.Range(_xSoftMovement.x, _xSoftMovement.y),
                    y: _toShake.position.y + Random.Range(_ySoftMovement.x, _ySoftMovement.y), iterations: _iterations);
    }
}
