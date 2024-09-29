using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeLifePick : PickUp
    {
        #region Variables

        [Header("Other pickup settings")]
        [SerializeField] private int _changeValue;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.ChangeLife(_changeValue);
        }

        #endregion
    }
}