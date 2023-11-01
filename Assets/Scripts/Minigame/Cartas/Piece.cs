using System.Linq;
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
        public bool Complete { get => _pieceCorrect; private set => _pieceCorrect = value; }
        [SerializeField] private bool _pieceCorrect = false;

        public delegate void DelegatePiece();
        public static DelegatePiece OnUpdatePiece;

        //[SerializeField] private Vector2 _clampY = new(-4.25f, 4.25f); 
        //[SerializeField] private Vector2 _clampX = new(-6.35f, 6.35f);

        #region onEnable
        private void OnEnable()
        {
            PointerCheck.OnPlaced += CheckPoints;
        }

        private void OnDisable()
        {
            PointerCheck.OnPlaced -= CheckPoints;
        }
        #endregion

        private void Start()
        {
            if (_pointers == null)
                _pointers = GetComponentsInChildren<PointerCheck>();

            _cam = Camera.main;
            //_clampX += new Vector2(-transform.parent.position.x, transform.parent.position.x);
        }

        public void SetUp(Sprite sp, int id, Vector2 clampX, Vector2 clampY)
        {
            _sp.sprite = sp;
            _id = id;
            //_clampX = clampX + new Vector2(-transform.parent.position.x, transform.parent.position.x);
            //_clampY = clampY;
        }

        private void CheckPoints()
        {
            for (int i = 0; i < _pointers.Length; i++)
            {
                if (!_pointers[i].Correct)
                {
                    Complete = false;
                    return;
                }
            }

            Complete = true;
        }

        #region On_Mouse Events
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

            OnUpdatePiece?.Invoke();
        }
        #endregion
    }
}