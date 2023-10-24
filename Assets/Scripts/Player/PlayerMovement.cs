using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _movement;
        private Rigidbody2D _rb;

        private void Awake()
        {
            TryGetComponent(out _rb);
        }

        #region input reader

        private void OnMove(InputValue dir)
        {
            _movement = dir.Get<Vector2>();
        }

        #endregion

        private void FixedUpdate()
        {
            if (Main.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY) return;

            _rb.MovePosition(_rb.position + _speed * Time.fixedDeltaTime * _movement);
        }
    }
}