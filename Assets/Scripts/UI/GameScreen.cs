using Arkanoid.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private AudioClip _levelTheme;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.OnScoreChanged += ScoreChangedCallback;
            UpdateScore();
            AudioService.Instance.StopAll();
            AudioService.Instance.PlaySfx(_levelTheme);
        }

        private void OnDestroy()
        {
            GameService.Instance.OnScoreChanged -= ScoreChangedCallback;
        }

        #endregion

        #region Private methods

        private void ScoreChangedCallback(int score)
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }

        #endregion
    }
}