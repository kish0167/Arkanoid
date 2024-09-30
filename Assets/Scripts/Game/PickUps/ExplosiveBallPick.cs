using Arkanoid.Game;
using Arkanoid.Game.PickUps;
using Arkanoid.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid
{
    public class ExplosiveBallPick : PickUp
    {
        #region Variables

        [Header("Other pickup settings")]
        [SerializeField] private float _durationSeconds = 15f;
        [FormerlySerializedAs("_explosionPrefab")] [SerializeField]
        private ArkanoidExplosion _arkanoidExplosionPrefab;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.MakeExplosive(_arkanoidExplosionPrefab, _durationSeconds);
            }
        }

        #endregion
    }
}