using Arkanoid.Services;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DupeBallsPick : PickUp
    {
        #region Variables

        [Header("Other pickup settings")]
        [SerializeField] private int _copiesCount = 2;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            for (int i = 0; i < _copiesCount; i++)
            {
                foreach (Ball ball in LevelService.Instance.Balls)
                {
                    Vector2 velocity = ball.GetRigidBody().velocity;
                    Vector3 position = ball.transform.position;
                    Ball newBall = Instantiate(ball, position += ArkanoidRandom.GetRandomVector3(),
                        Quaternion.identity);
                    newBall.ForceStart();
                    newBall.GetRigidBody().velocity = velocity + ArkanoidRandom.GetRandomVector2() * velocity.magnitude;
                }
            }
        }

        #endregion
    }
}