using Arkanoid.Services;
using Unity.Mathematics;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Variables
        
        [Header("Default pickup settings")]
        [SerializeField] private int _scoreValue;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private GameObject _vfxPrefab;
        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tag.Platform))
            {
                return;
            }

            PerformActions();
            Destroy(gameObject);
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            GameService.Instance.AddScore(_scoreValue);
            if (_vfxPrefab != null)
            {
                Instantiate(_vfxPrefab, transform.position, quaternion.identity);
            }

            AudioService.Instance.PlaySfx(_audioClip);
        }

        #endregion
    }
}