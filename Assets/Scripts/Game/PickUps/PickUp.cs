using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {

        [SerializeField] private int _scoreValue;
        
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
            // TODO: Play vfx
            // TODO: Play sound
        }

        #endregion
    }
}