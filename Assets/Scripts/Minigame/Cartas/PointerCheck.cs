using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Rebuild
{
    public class PointerCheck : MonoBehaviour
    {
        [SerializeField] private Piece _target;

        [SerializeField] private bool _correct;
        [SerializeField] private List<GameObject> _inside = new();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Piece")) return;

            if (!_inside.Contains(collision.gameObject))
            {
                _inside.Add(collision.gameObject);
            }

            Debug.Log("equals? : " + collision.gameObject.Equals(_target.gameObject));

            if (collision.gameObject.Equals(_target.gameObject))
            {
                _correct = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Piece")) return;

            _inside.Remove(collision.gameObject);
            if (collision.gameObject.Equals(_target.gameObject))
            {
                _correct = false;
            }
        }
    }
}
