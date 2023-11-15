using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace OniricFall
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Transform _spiral;
        [SerializeField] private float _rotSpeed;
        [SerializeField] private float _timeScaling;
        [SerializeField] private float _maxScaleSize;

        private void Start()
        {
            FMODSpecial.instance.ChangeMusic(EnumsData.MusicScene.SCENE1);

            DialogueManager.StartConversation("Fall");

            CodeAnimation.Animate(_spiral, _timeScaling, CodeAnimation.CurveType.LINEAR,
                xScale: _maxScaleSize, yScale: _maxScaleSize,
                onComplete:
                delegate
                {
                    LoaderScenes.Instance.LoadScene("FirstScene_Awakening");
                });

            FadesController.Instance.FadeIn(_timeScaling - 1f, 1, 1);
        }

        private void Update()
        {
            _spiral.Rotate(new(0, 0, 10 * -_rotSpeed * Time.deltaTime));
        }
    }
}