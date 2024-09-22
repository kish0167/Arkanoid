using Arkanoid.Services;

namespace Arkanoid.Game.PickUps
{
    public class AddLifePick : PickUp
    {
        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.AddLife();
        }
    }
}