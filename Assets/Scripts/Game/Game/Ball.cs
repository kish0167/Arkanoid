using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;

        private bool _isStarted;
        private Platform _platform;

        #endregion

        #region Events

        public static event Action OnBallDied;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _platform = FindObjectOfType<Platform>();

            GameService.Respawn += MoveToPlatform;
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            MoveWithPlatform();

            if (Input.GetMouseButtonDown(0))
            {
                StartFlying();
            }
        }

        private void OnDestroy()
        {
            GameService.Respawn -= MoveToPlatform;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("KillerBorder"))
            {
                OnBallDied?.Invoke();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
        }

        #endregion

        #region Private methods

        private void MoveToPlatform()
        {
            gameObject.transform.position = _platform.transform.position + new Vector3(0, 1f, 0);
            _rb.velocity = Vector2.zero;
            _isStarted = false;
        }

        private void MoveWithPlatform()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _platform.transform.position.x;
            transform.position = currentPosition;
        }

        private void StartFlying()
        {
            _isStarted = true;
            Vector2 randomVector2 = new(Random.Range(-1f, 1f), Random.Range(0.2f, 1f));
            _rb.velocity = randomVector2.normalized * _speed;
        }

        #endregion
    }
}