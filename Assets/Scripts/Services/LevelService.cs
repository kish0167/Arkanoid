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

        private readonly List<Block> _blocks = new();

        #endregion

        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Properties

        public Ball Ball { get; private set; }
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

        public void RescaleBall(float coef)
        {
            if (Ball == null)
            {
                return;
            }

            //Vector3 scale = Ball.transform.localScale;
            //scale.Scale(new Vector3(coef, coef, 1));
            Ball.transform.localScale = new Vector3(coef, coef, 1);
        }

        public void RescalePlatformWidth(float coef)
        {
            if (Platform == null)
            {
                return;
            }

            Platform.transform.localScale = new Vector3(coef, 1f, 1f);
        }

        #endregion

        #region Private methods

        private void BallCreatedCallback(Ball ball)
        {
            Ball = ball;
        }

        private void BallDestroyedCallback(Ball ball)
        {
            Ball = null;
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

        public void AccelerateBall(float coef)
        {
            Vector2 velocity = Ball.GetRigidBody().velocity;
            velocity.Scale(new Vector2(coef, coef));
            Ball.GetRigidBody().velocity = velocity;
        }

        #endregion
    }
}