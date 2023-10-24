using UnityEngine;

namespace Cam
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private SceneSettings _sceneSettings;
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothTime = 0.2f;
        private Vector2 _velocityRef;

        private Vector2 _clampX;
        private Vector2 _clampY;

        private void Awake()
        {
            _velocityRef = Vector3.zero;
            _clampX = _sceneSettings.CameraClampingX;
            _clampY = _sceneSettings.CameraClampingY;
        } 

        private void LateUpdate()
        {
            //NOT forget put rigibody interpolation!!!
            Vector3 smooth = Vector2.SmoothDamp(transform.position, _target.position, ref _velocityRef, _smoothTime);

            smooth.z = -10; 
            smooth.x = Mathf.Clamp(smooth.x, _clampX.x, _clampX.y);
            smooth.y = Mathf.Clamp(smooth.y, _clampY.x, _clampY.y);

            transform.position = smooth;
        }
    }
}