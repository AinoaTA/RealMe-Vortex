using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Animator _playerAnimator;
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

            if (GameManager.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY)
            {
                _playerAnimator.SetBool("Walking", false);
            }
            else
            {
                if (dir.magnitude != 0)
                    _playerAnimator.transform.parent.localScale = dir.x > 0 ? new(-1, 1, 1) : Vector3.one;

                _playerAnimator.SetBool("Walking", dir.magnitude != 0);
            }
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