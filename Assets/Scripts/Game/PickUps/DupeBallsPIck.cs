using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DupeBallsPick : PickUp
    {
        #region Variables

        [SerializeField] private int _copiesCount = 2;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            LevelService.Instance.DupeBalls(_copiesCount);
        }

        #endregion
    }
}