using Arkanoid.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class GameWinScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private Button _exitButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _exitButton.onClick.AddListener(ExitButtonClickedCallback);
            _scoreLabel.text = $"score: {GameService.Instance.Score}";
        }

        #endregion

        #region Public methods

        public void ExitButtonClickedCallback()
        {
            SceneLoaderService.Instance.ExitGame();
        }

        #endregion
    }
}