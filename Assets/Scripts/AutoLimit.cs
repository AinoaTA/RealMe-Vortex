using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
namespace Others
{
    public enum Side { LEFT, RIGHT}
    [ExecuteAlways]
    public class AutoLimit : MonoBehaviour
    {
        [SerializeField] private SceneSettings _settings;
        [SerializeField] private Side _side;

        private void Reset()
        {
            if (_settings == null) return;

            TryGetComponent(out SpriteRenderer sp);

            float bounds = sp.bounds.size.x;


            transform.position = _side == Side.LEFT ? new(_settings.CameraClampingX.x - bounds, 0) :
                transform.position = new(_settings.CameraClampingX.y + bounds, 0);
        }

        private void Update()
        {
            Reset();
        }
    }

}
#endif