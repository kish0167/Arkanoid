using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class RescalePlatformPick : PickUp
    {
        #region Variables

        [Header("Other pickup settings")]
        [SerializeField] private float _resizeCoefficient = 1.5f;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            if (LevelService.Instance.Platform == null)
            {
                return;
            }

            LevelService.Instance.Platform.transform.localScale = new Vector3(_resizeCoefficient, 1f, 1f);
        }

        #endregion
    }
}