using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DummyPickUp : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            Debug.Log("DummyPickUp PerformActions");
        }

        #endregion
    }
}