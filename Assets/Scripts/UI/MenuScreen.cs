using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _levelButtonPrefab;
        [SerializeField] private HorizontalLayoutGroup _levelSelector;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            foreach (string levelSceneName in SceneLoaderService.Instance.LevelSceneNames)
            {
                Button newButton = Instantiate(_levelButtonPrefab, _levelSelector.transform);
                newButton.gameObject.name = levelSceneName + " - Button";
                ArcanoidButton newArcanoidButton = newButton.GetComponent<ArcanoidButton>();
                newArcanoidButton.LevelToLoadName = levelSceneName;
                newArcanoidButton.ButtonLabel.text = levelSceneName;
                newButton.onClick.AddListener(newArcanoidButton.ButtonClickedCallback);
            }
        }

        #endregion
    }
}