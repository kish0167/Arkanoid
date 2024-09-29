using System;
using System.Collections.Generic;
using Arkanoid.Game.PickUps;
using Arkanoid.Utility;
using UnityEngine;
using UnityEngine.Serialization;
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
                sum += p.probability;
            }

            float cumulative = 0f;
            float randomValue = Random.Range(0f, sum);

            foreach (PickUpAndProbability pickup in _pickUpsVariants)
            {
                cumulative += pickup.probability;
                if (randomValue < cumulative)
                {
                    return pickup.pickUpPrefab;
                }
            }

            return null;
        }

        #endregion

        #region Local data

        [Serializable] private struct PickUpAndProbability
        {
            #region Variables

            [FormerlySerializedAs("PickUpPrefab")] [SerializeField] public PickUp pickUpPrefab;
            [FormerlySerializedAs("Probability")]
            [Header("relative probability, not actual percentage")]
            [Range(0f, 100f)]
            [SerializeField] public float probability;

            #endregion
        }

        #endregion
    }
}