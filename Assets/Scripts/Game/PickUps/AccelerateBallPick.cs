using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class AccelerateBallPick : PickUp
    {
        #region Variables

        [SerializeField] private float _coefficient = 1.5f;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            foreach (Ball ball in LevelService.Instance.Balls)
            {
                Vector2 velocity = ball.GetRigidBody().velocity;
                velocity.Scale(new Vector2(_coefficient, _coefficient));
                ball.GetRigidBody().velocity = velocity;
            }
        }

        #endregion
    }
}