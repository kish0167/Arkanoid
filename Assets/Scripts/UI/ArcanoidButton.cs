using System.Collections;
using System.Collections.Generic;
using Arkanoid.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class ArcanoidButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _buttonLabel;

        public TMP_Text ButtonLabel => _buttonLabel;

        public string LevelToLoadName { get; set; }

        public void ButtonClickedCallback()
        {
            SceneLoaderService.Instance.LoadLevelWithName(LevelToLoadName);
        }
        

    }
}
