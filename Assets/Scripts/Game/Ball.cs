using System;
using System.Collections;
using Arkanoid.Services;
using Unity.Mathematics;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startDirection;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _yOffsetFromPlatform = 1;
        [SerializeField] private AudioClip _defaultHitSfx;

        private ArkanoidExplosion _arkanoidExplosionPrefab;

        private bool _isStarted;
        private Platform _platform;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Properties

        public bool IsExplosive { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _platform = FindObjectOfType<Platform>();
            IsExplosive = false;

            OnCreated?.Invoke(this);

            if (GameService.Instance.IsAutoPlay)
            {
                StartFlying();
            }
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
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!IsExplosive)
            {
                AudioService.Instance.PlaySfx(_defaultHitSfx);
                return;
            }

            Instantiate(_arkanoidExplosionPrefab, transform.position, quaternion.identity);
        }

        private void OnDrawGizmos()
        {
            if (!_isStarted)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_startDirection);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
            }
        }

        #endregion

        #region Public methods

        public void ForceStart()
        {
            _isStarted = true;
        }

        public Rigidbody2D GetRigidBody()
        {
            return _rb;
        }

        public void MakeExplosive(ArkanoidExplosion arkanoidExplosionPrefab, float duration)
        {
            if (IsExplosive)
            {
                return;
            }

            _arkanoidExplosionPrefab = arkanoidExplosionPrefab;
            IsExplosive = true;
            StartCoroutine(MakeNonExplosive(duration));
        }

        public void ResetBall()
        {
            _isStarted = false;
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Private methods

        private IEnumerator MakeNonExplosive(float duration)
        {
            yield return new WaitForSeconds(duration);
            _arkanoidExplosionPrefab = null;
            IsExplosive = false;
        }

        private void MoveWithPlatform()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _platform.transform.position.x;
            currentPosition.y = _platform.transform.position.y + _yOffsetFromPlatform;
            transform.position = currentPosition;
        }

        private void StartFlying()
        {
            _isStarted = true;
            _rb.velocity = _startDirection.normalized * _speed;
        }

        #endregion
    }
}