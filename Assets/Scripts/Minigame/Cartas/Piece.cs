using UnityEngine;

namespace Minigames.Rebuild
{
    public class Piece : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sp;
        private PointerCheck[] _pointers;
        private int _id;

        private bool _dragging;
        private Camera _cam;
        [SerializeField] private Vector2 _clampY = new(-4.25f, 4.25f);

        [SerializeField] private Vector2 _clampX = new(-6.35f, 6.35f);

        private void Start()
        {
            if (_pointers == null)
                _pointers = GetComponentsInChildren<PointerCheck>();

            _cam = Camera.main;
            _clampX += new Vector2(-transform.parent.position.x, transform.parent.position.x);
        }

        public void SetUp(Sprite sp, int id, Vector2 clampX, Vector2 clampY)
        {
            _sp.sprite = sp;
            _id = id;
            _clampX = clampX + new Vector2(-transform.parent.position.x, transform.parent.position.x);
            _clampY = clampY;
        }

        public void OnMouseDown()
        {
            _dragging = true;
        }

        public void OnMouseDrag()
        {
            if (_dragging)
            {
                Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                transform.position = mousePos;
            }
        }

        public void OnMouseUp()
        {
            _dragging = false;
        }
    }
}