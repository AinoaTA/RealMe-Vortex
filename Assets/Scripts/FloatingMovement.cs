using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    [Header("Amplitude")]
    [SerializeField] private float _xMinAmplitude = 0.01f;
    [SerializeField] private float _xMaxAmplitude = 0.05f;
    [SerializeField] private float _yMinAmplitude = 0.01f;
    [SerializeField] private float _yMaxAmplitude = 0.05f;

    [Header("Speed")]
    [SerializeField] private float _xSpeed = 0.01f;
    [SerializeField] private float _ySpeed = 0.01f;

    [Header("Rotation")]
    [SerializeField] private bool _canRotate = false;
    [SerializeField]private float _maxRotation=15f;
    [SerializeField] private float _rotationSpeed=0.5f;

    private float _xAngle;
    private float _yAngle;

    private float _xAmplitude;
    private float _yAmplitude;

    private Vector3 _originalPosition;
    [Space(20)]
    public bool Enabled = true; 
  
    private void Awake()
    {
        if (Enabled == false) return;

        _originalPosition = transform.localPosition;

        _xAngle = Random.Range(0, 2 * Mathf.PI);
        _yAngle = Random.Range(0, 2 * Mathf.PI);

        _xAmplitude = Random.Range(_xMinAmplitude, _xMaxAmplitude);
        _yAmplitude = Random.Range(_yMinAmplitude, _yMaxAmplitude);
        SetPosition();
    }

    private void Update()
    {
        if (Enabled == false) return;

        _xAngle = _xAngle + _xSpeed;
        _yAngle = _yAngle + _ySpeed;
        if (_xAngle > 360) _xAngle -= 360;
        if (_yAngle > 360) _yAngle -= 360;
        SetPosition();
    }

    private void SetPosition()
    {
        transform.localPosition = _originalPosition + new Vector3(_xAmplitude * Mathf.Sin(_xAngle), _yAmplitude * Mathf.Sin(_yAngle), 0);
        if (_canRotate)
            transform.rotation = Quaternion.Euler(0f, 0f, _maxRotation * Mathf.Sin(Time.time * _rotationSpeed));
    }

    public void Enable()
    {
        Enabled = true;
        Awake();
    }
}
