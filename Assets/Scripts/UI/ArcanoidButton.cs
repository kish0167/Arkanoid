using Arkanoid.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class ArcanoidButton : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _buttonLabel;

        #endregion

        #region Properties

        public TMP_Text ButtonLabel => _buttonLabel;

        public string LevelToLoadName { get; set; }

        #endregion

        #region Public methods

        public void ButtonClickedCallback()
        {
            SceneLoaderService.Instance.LoadLevelWithName(LevelToLoadName);
        }

        #endregion
    }
}