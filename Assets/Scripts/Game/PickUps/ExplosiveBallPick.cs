using System.Collections;
using System.Collections.Generic;
using Arkanoid.Game;
using Arkanoid.Game.PickUps;
using Arkanoid.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid
{
    public class ExplosiveBallPick : PickUp
    {
        [Header("Other pickup settings")]
        [SerializeField] private float _durationSeconds = 15f;
        [FormerlySerializedAs("_explosionPrefab")] [SerializeField] private ArkanoidExplosion _arkanoidExplosionPrefab;


        
        protected override void PerformActions()
        {
            base.PerformActions();
            foreach (Ball ball in LevelService.Instance.Balls)
            {
                //StartCoroutine(ball.MakeExplosiveForSeconds(_durationSeconds, _explosionPrefab));
                ball.MakeExplosive(_arkanoidExplosionPrefab, _durationSeconds);
            }
        }
    }
}
