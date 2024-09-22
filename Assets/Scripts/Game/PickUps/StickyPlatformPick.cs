using Arkanoid.Services;

namespace Arkanoid.Game.PickUps
{
    public class StickyPlatformPick : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            LevelService.Instance.Platform.IsSticky = true;
        }

        #endregion
    }
}