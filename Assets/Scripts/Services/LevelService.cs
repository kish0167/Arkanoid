using System;
using System.Collections.Generic;
using Arkanoid.Game;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Variables

        private readonly List<Ball> _balls = new();

        private readonly List<Block> _blocks = new();

        #endregion

        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Properties

        //public Ball Ball { get; private set; }
        public Platform Platform { get; private set; }

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            Block.OnCreated += BlockCreatedCallback;
            Block.OnDestroyed += BlockDestroyedCallback;
            Platform.OnCreated += PlatformCreatedCallback;

            Ball.OnCreated += BallCreatedCallback;
            Ball.OnDestroyed += BallDestroyedCallback;
        }

        private void OnDestroy()
        {
            Block.OnCreated -= BlockCreatedCallback;
            Block.OnDestroyed -= BlockDestroyedCallback;
            Platform.OnCreated -= PlatformCreatedCallback;

            Ball.OnCreated -= BallCreatedCallback;
            Ball.OnDestroyed -= BallDestroyedCallback;
        }

        #endregion

        #region Public methods

        public void AccelerateBalls(float coef)
        {
            foreach (Ball ball in _balls)
            {
                Vector2 velocity = ball.GetRigidBody().velocity;
                velocity.Scale(new Vector2(coef, coef));
                ball.GetRigidBody().velocity = velocity;
            }
        }

        public void DupeBalls(int count)
        {
            foreach (Ball ball in _balls)
            {
                Vector2 velocity = ball.GetRigidBody().velocity;
                Vector3 position = ball.transform.position;
                for (int i = 0; i < count; i++)
                {
                    Ball newBall = Instantiate(ball, position += ArkanoidRandom.GetRandomVector3(),
                        Quaternion.identity);
                    newBall.ForseStart();
                    newBall.GetRigidBody().velocity = velocity;
                }
            }
        }

        public Ball GetFirstBall()
        {
            if (_balls.Count == 0)
            {
                return null;
            }

            return _balls[0];
        }

        public bool IsLastBall()
        {
            return _balls.Count < 2;
        }

        public void RescaleBalls(float coef)
        {
            if (_balls.Count == 0)
            {
                return;
            }

            foreach (Ball ball in _balls)
            {
                ball.transform.localScale = new Vector3(coef, coef, 1);
            }
        }

        public void RescalePlatformWidth(float coef)
        {
            if (Platform == null)
            {
                return;
            }

            Platform.transform.localScale = new Vector3(coef, 1f, 1f);
        }

        public void ResetBalls()
        {
            foreach (Ball ball in _balls)
            {
                ball.ResetBall();
                if (GameService.Instance.IsAutoPlay)
                {
                    ball.ForseStart();
                }
            }
        }

        #endregion

        #region Private methods

        private void BallCreatedCallback(Ball ball)
        {
            _balls.Add(ball);
        }

        private void BallDestroyedCallback(Ball ball)
        {
            _balls.Remove(ball);
        }

        private void BlockCreatedCallback(Block block)
        {
            _blocks.Add(block);
        }

        private void BlockDestroyedCallback(Block block)
        {
            _blocks.Remove(block);

            if (_blocks.Count == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        private void PlatformCreatedCallback(Platform obj)
        {
            Platform = obj;
        }

        #endregion
    }
}