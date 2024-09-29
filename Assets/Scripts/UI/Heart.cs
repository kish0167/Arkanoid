using System;
using UnityEngine;

namespace Arkanoid
{
    public class Heart : MonoBehaviour
    {
        #region Events

        public static event Action<Heart> OnCreated;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        #endregion

        #region Public methods

        public void DestroyMe()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}