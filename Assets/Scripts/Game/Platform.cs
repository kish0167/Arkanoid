using System;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Variables

        private bool _isSticky;

        #endregion

        #region Events

        public static event Action<Platform> OnCreated;

        #endregion

        #region Properties

        public bool IsSticky
        {
            get => _isSticky;
            set => _isSticky = value;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            if (GameService.Instance.IsAutoPlay)
            {
                MoveWithBall();
            }
            else
            {
                MoveWithMouse();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tag.Platform) && IsSticky)
            {
                LevelService.Instance.Ball.ResetBall();
                IsSticky = false;
            }
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Ball ball = LevelService.Instance.Ball;
            if (ball == null)
            {
                return;
            }

            SetXPosition(ball.transform.position.x);
        }

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = x;
            transform.position = currentPosition;
        }

        #endregion
    }
}