using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentGameObject;
        [SerializeField] private Button _restartButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonClickedCallback);
        }

        private void Start()
        {
            GameService.Instance.OnGameOver += GameOverCallback;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnGameOver -= GameOverCallback;
        }

        #endregion
  
        #region Private methods

        private void RestartButtonClickedCallback()
        {
            GameService.Instance.IsGameOver = false;
            GameService.Instance.ResetLives();
            SceneLoaderService.Instance.LoadFirstLevel();
        }

        private void GameOverCallback()
        {
            _contentGameObject.SetActive(true);
        }
        
        private void GameRestartCallback()
        {
            _contentGameObject.SetActive(true);
        }

        #endregion
    }
}