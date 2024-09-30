using System.Collections;
using System.Collections.Generic;
using Arkanoid.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class GameWinScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private Button _exitButton;
        
        
        void Start()
        {
            _exitButton.onClick.AddListener(ExitButtonClickedCallback);
            _scoreLabel.text = $"score: {GameService.Instance.Score}";
        }

        public void ExitButtonClickedCallback()
        {
            SceneLoaderService.Instance.ExitGame();
        }
    }
}
