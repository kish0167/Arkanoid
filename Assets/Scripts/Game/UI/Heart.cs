using UnityEngine;

public class Heart : MonoBehaviour
{
    #region Public methods

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    #endregion
}