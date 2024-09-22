using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class AccelerateBallPick : PickUp
    {
        [SerializeField] private float _coefficient = 1.5f;
        
        protected override void PerformActions()
        {
            base.PerformActions();

            LevelService.Instance.AccelerateBalls(_coefficient);
        }
    }
}