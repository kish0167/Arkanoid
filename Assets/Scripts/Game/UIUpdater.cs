using System.Collections;
using System.Collections.Generic;
using Arkanoid.Game;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreLabel;
    
    void Update()
    {
        _scoreLabel.text = $"score:\n{ScoreTracker.Score}";
    }
}
