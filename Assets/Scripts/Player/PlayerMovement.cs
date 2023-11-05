using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _movement;
        private Rigidbody2D _rb;

        private void OnEnable()
        {
            InputManager.OnMoveDelegate += OnMove;
        }

        private void OnDisable()
        {
            InputManager.OnMoveDelegate -= OnMove;
        }

        private void Awake()
        {
            TryGetComponent(out _rb);
        }

        #region input reader

        private void OnMove(Vector2 dir)
        {
            _movement = dir;
        }

        #endregion

        private void FixedUpdate()
        {
            if (GameManager.instance.GameStatus == null) return;
            if (GameManager.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY) return;

            _rb.MovePosition(_rb.position + _speed * Time.fixedDeltaTime * _movement);
        }
    }
}