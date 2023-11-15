using System.Collections;
using UnityEngine;

namespace Cam
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private Vector2 _xSoftMovement, _ySoftMovement;
        [SerializeField] private float _time = 0.25f;
        [SerializeField] private int _iterations = 3;

        private Coroutine _routineLoop;

        #region Init
        Vector3 _reset;
        private void Awake()
        {
            _reset = transform.position;
        }
        #endregion

        #region Shakes
        public void SoftShake()
        {
            CodeAnimation.Animate(transform, _time, CodeAnimation.CurveType.SOFT_LOOP, x: transform.position.x + Random.Range(_xSoftMovement.x, _xSoftMovement.y),
                y: transform.position.y + Random.Range(_ySoftMovement.x, _ySoftMovement.y), iterations: _iterations);

            //StartCoroutine(ForceZeroPosition(_time * _iterations));
        }

        public void LongShake() 
        {
            CodeAnimation.Animate(transform, _time, CodeAnimation.CurveType.SOFT_LOOP, x: transform.position.x + Random.Range(_xSoftMovement.x, _xSoftMovement.y),
                    y: transform.position.y + Random.Range(_ySoftMovement.x, _ySoftMovement.y), iterations: _iterations*2);
        }

        public void LoopSoftShake()
        {
            if (_routineLoop != null) CodeAnimation.Stop(_routineLoop);

            _routineLoop = CodeAnimation.Animate(transform, _time, CodeAnimation.CurveType.SOFT_LOOP, x: transform.position.x + 0.3f,
                y: transform.position.y + 0.3f,/* iterations: _iterations,*/ loop:true);
             
        }

        public void LoopHardtShake()
        {
            if (_routineLoop != null) CodeAnimation.Stop(_routineLoop);

            _routineLoop = CodeAnimation.Animate(transform, _time/1.3f, CodeAnimation.CurveType.SOFT_LOOP, x: transform.position.x + 0.6f,
                y: transform.position.y + 0.6f,/* iterations: _iterations,*/ loop: true);

        }

        public void CustomImmediateShake(float time, CodeAnimation.CurveType curve, float xVariation, float yVariation, int iterations)
        {
            CodeAnimation.Animate(transform, time, curve, x: transform.position.x + xVariation,
                    y: transform.position.y + yVariation, iterations: iterations);

            //StartCoroutine(ForceZeroPosition(time * iterations));
        }
        #endregion

        IEnumerator ForceZeroPosition(float waitingTime)
        {
            yield return new WaitForSeconds(waitingTime);
            transform.position = _reset;
        }
    }
}