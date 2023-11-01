using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Rebuild
{
    public class PointerCheck : MonoBehaviour
    {
        [SerializeField] private Piece _target;

        public bool Correct { get => _correct; private set => _correct = value; }
        [SerializeField] private bool _correct = false;

        [SerializeField] private List<GameObject> _inside = new();

        public delegate void DelegatePiece();
        public static DelegatePiece OnPlaced;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Piece")) return;

            if (!_inside.Contains(collision.gameObject))
            {
                _inside.Add(collision.gameObject);
            }

            if (collision.gameObject.Equals(_target.gameObject))
            {
                Correct = true;
                OnPlaced?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Piece")) return;

            _inside.Remove(collision.gameObject);
            if (collision.gameObject.Equals(_target.gameObject))
            {
                Correct = false;
                OnPlaced?.Invoke();
            }
        }
    }
}