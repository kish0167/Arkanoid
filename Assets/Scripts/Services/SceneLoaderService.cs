using Arkanoid.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Variables

        [SerializeField] private string[] _levelSceneNames;

        [SerializeField] private string _startSceneName;
        

        private int _currentSceneIndex;

        #endregion

        #region Properties

        public string[] LevelSceneNames => _levelSceneNames;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            DetectCurrentSceneIndex();
        }

        #endregion

        #region Public methods

        public bool HasNextLevel()
        {
            return _levelSceneNames.Length > _currentSceneIndex + 1;
        }

        public void LoadFirstLevel()
        {
            _currentSceneIndex = 0;
            LoadCurrentScene();
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(_startSceneName);
            Debug.LogError("??????");
        }

        private int GetSceneIndex(string levelName)
        {
            for (int i = 0; i < _levelSceneNames.Length; i++)
            {
                if (string.Equals(_levelSceneNames[i], levelName))
                {
                    return i;
                }
            }

            return -1;
        }

        public void LoadLevelWithName(string levelName)
        {
            _currentSceneIndex = GetSceneIndex(levelName);
            LoadCurrentScene();
        }

        public void LoadNextLevel()
        {
            _currentSceneIndex++;
            LoadCurrentScene();
        }

        #endregion

        #region Private methods

        private void DetectCurrentSceneIndex()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            _currentSceneIndex = -1;

            for (int i = 0; i < _levelSceneNames.Length; i++)
            {
                if (string.Equals(currentSceneName, _levelSceneNames[i]))
                {
                    _currentSceneIndex = i;
                    return;
                }
            }
        }

        private void LoadCurrentScene()
        {
            SceneManager.LoadScene(_levelSceneNames[_currentSceneIndex]);
        }

        #endregion
    }
}