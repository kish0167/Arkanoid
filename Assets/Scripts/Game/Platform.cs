using System;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Events

        public static event Action<Platform> OnCreated;
        public static event Action<Platform> OnDestroyed;

        #endregion

        #region Properties

        public bool IsSticky { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void Update()
        {
            if (PauseService.Instance.IsPaused || GameService.Instance.IsGameOver)
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

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(Tag.Ball) || !IsSticky)
            {
                return;
            }

            other.gameObject.GetComponent<Ball>().ResetBall();
            IsSticky = false;
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Ball ball = LevelService.Instance.GetFirstBall();
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