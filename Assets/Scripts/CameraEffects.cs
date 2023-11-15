using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Cam
{
    public class CameraEffects : MonoBehaviour
    {
        [SerializeField] private PostProcessVolume volume;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _target;

        [SerializeField] private bool _enableVignette;
        [SerializeField] private Vector2 _vignetteValues = new(0.1f, 0.8f);
        private Vignette vg;
        private float _min = 1;
        private IEnumerator _routineVariation;

        private float _dfValueVG;
        private void Start()
        {
            if (_player == null) return;

            volume.profile.TryGetSettings(out vg);
            _dfValueVG = vg.intensity;


            //VariationVignette(0.2f);
            //ModifyVignete();

            //VariationVignette(0.25f);
        }

        //public void ModifyVignete()
        //{ 
        //    vg.intensity.value = 0.5f;
        //}

        private void Update()
        {
            if (_enableVignette && (_target != null))
                vg.intensity.value = Mathf.Lerp(_vignetteValues.x, _vignetteValues.y, _min / Vector2.Distance(_player.position, _target.position));
        }

        #region Special Functions

        public void EnableObscureRad(bool enable)
        {
            _enableVignette = enable;
        }

        //vignette
        public void WorseVignette()
        {
            _vignetteValues.x += 0.15f;
            _vignetteValues.x = Mathf.Clamp(_vignetteValues.x, 0.15f, 1);
        }

        public void BetterVignette()
        {
            _vignetteValues.x -= 0.15f;
            _vignetteValues.x = Mathf.Clamp(_vignetteValues.x, 0.15f, 1);
        }

        public void VariationVignette(float timesBetweenRep)
        {
            if (_routineVariation != null) StopCoroutine(_routineVariation);
            StartCoroutine(_routineVariation = VariationRoutine(timesBetweenRep));
        }

        IEnumerator VariationRoutine(float timeBetweenRep = 0.5f, int rep = 1)
        {
            int times = 0;
            float val = vg.intensity.value;
            bool overMid = val > 0.5f;

            while (times < rep)
            {
                float t = 0;
                while (t < timeBetweenRep)
                {
                    vg.intensity.value = Mathf.Lerp(val, 0.7f, t / timeBetweenRep);
                    t += Time.deltaTime;
                    yield return null;
                }

                yield return null;
                t = 0;
                val = vg.intensity.value;
                while (t < timeBetweenRep)
                {
                    vg.intensity.value = Mathf.Lerp(val, _dfValueVG, t / timeBetweenRep);
                    t += Time.deltaTime;
                    yield return null;
                }

                times++;
            }
        }
        #endregion
    }
}