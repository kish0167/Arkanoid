using System;
using Arkanoid.Services;
using Unity.Mathematics;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _score = 16;

        [Header("Explosive")]
        [SerializeField] private bool _isExplosive;
        [SerializeField] private GameObject _explosionPrefab;

        #endregion

        #region Events

        public static event Action<Block> OnCreated;
        public static event Action<Block> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroyBlock();
        }

        #endregion

        #region Public methods

        public void ForceDestroy()
        {
            DestroyBlock();
        }

        #endregion

        #region Private methods

        private void DestroyBlock()
        {
            GameService.Instance.AddScore(_score);
            PickUpService.Instance.SpawnPickUp(transform.position);
            Destroy(gameObject);
            Explode();
        }

        private void Explode()
        {
            if (_isExplosive)
            {
                Instantiate(_explosionPrefab, transform.position, quaternion.identity);
            }
        }

        #endregion
    }
}