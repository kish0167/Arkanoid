using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ResizeBallPick : PickUp
    {
        #region Variables

        [SerializeField] private float _resizeCoefficient = 1.5f;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            if (LevelService.Instance.Balls.Count == 0)
            {
                return;
            }

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                ball.transform.localScale = new Vector3(_resizeCoefficient, _resizeCoefficient, 1);
            }
        }

        #endregion
    }
}