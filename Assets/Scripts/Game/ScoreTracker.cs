using TMPro;
using UnityEngine;

namespace Arkanoid.Game
{
    public static class ScoreTracker
    {
        #region Variables

        private static int _score;

        #endregion

        #region Properties

        public static int Score
        {
            get => _score;
            set => _score = value;
        }
        #endregion
    }
}