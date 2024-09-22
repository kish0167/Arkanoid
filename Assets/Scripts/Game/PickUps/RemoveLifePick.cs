using Arkanoid.Services;

namespace Arkanoid.Game.PickUps
{
    public class RemoveLifePick : PickUp
    {
        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.RemoveLife();
        }
    }
}