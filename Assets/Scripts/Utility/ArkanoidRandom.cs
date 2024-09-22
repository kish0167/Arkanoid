using UnityEngine;

namespace Arkanoid.Utility
{
    public static class ArkanoidRandom
    {
        #region Public methods

        public static Vector3 GetRandomVector3()
        {
            float fi = Random.Range(0f, Mathf.PI);
            return new Vector3(Mathf.Cos(fi), Mathf.Sin(fi), 0);
        }

        #endregion
    }
}