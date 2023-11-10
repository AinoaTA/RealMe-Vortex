using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
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

        private void Start()
        {
            ModifyVignete();

            VariationVignette(0.25f);
        }

        public void ModifyVignete()
        {
            volume.profile.TryGetSettings(out vg);
            vg.intensity.value = 0.5f;
        }

        private void Update()
        {
            if (_enableVignette)
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

        IEnumerator VariationRoutine(float timeBetweenRep = 0.5f, int rep = 5)
        {
            int times = 0;
            float val = vg.intensity.value;
            bool overMid = val > 0.5f;
             
            while (times < rep)
            {
                float t = 0;
                while (t < timeBetweenRep)
                {
                    vg.intensity.value = Mathf.Lerp(val, overMid ? 0.2f : 0.7f, t / 0.5f);
                    t += Time.deltaTime;
                    yield return null;
                }

                yield return null;
                t = 0;
                while (t < timeBetweenRep)
                {
                    vg.intensity.value = Mathf.Lerp(overMid ? 0.2f : 0.7f, val, t / 0.5f);
                    t += Time.deltaTime;
                    yield return null;
                }

                times++;
            }
        } 
        #endregion 
    }
}