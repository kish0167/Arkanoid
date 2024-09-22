using System;
using System.Collections.Generic;
using Arkanoid.Game.PickUps;
using Arkanoid.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Header("Overall probability")]
        [Range(0f, 100f)]
        [SerializeField] private float _commonProbability;

        [Header("Prefabs list with probabilities")]
        [SerializeField] private List<PickUpAndProbability> _pickUpsVariants;

        #endregion

        #region Public methods

        public void SpawnPickUp(Vector3 position)
        {
            if (_pickUpsVariants.Count == 0)
            {
                return;
            }

            if (Random.Range(0f, 100f) > _commonProbability)
            {
                return;
            }

            Instantiate(GetRandomFromList(_pickUpsVariants), position, Quaternion.identity);
        }

        #endregion

        #region Private methods

        private PickUp GetRandomFromList(List<PickUpAndProbability> probsList)
        {
            float sum = 0f;

            foreach (PickUpAndProbability p in _pickUpsVariants)
            {
                sum += p.Probability;
            }

            float cumulative = 0f;
            float randomValue = Random.Range(0f, sum);

            foreach (PickUpAndProbability pickup in _pickUpsVariants)
            {
                cumulative += pickup.Probability;
                if (randomValue < cumulative)
                {
                    return pickup.PickUpPrefab;
                }
            }

            return null;
        }

        #endregion

        #region Local data

        [Serializable] private struct PickUpAndProbability
        {
            #region Variables

            [SerializeField] public PickUp PickUpPrefab;
            [Header("relative probability, not actual percentage")]
            [Range(0f, 100f)]
            [SerializeField] public float Probability;

            #endregion
        }

        #endregion
    }
}