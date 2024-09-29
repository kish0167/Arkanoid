using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class AddLifePick : PickUp
    {

        [SerializeField] private int _type;
        
        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.ChangeLife(1);
        }
    }
}