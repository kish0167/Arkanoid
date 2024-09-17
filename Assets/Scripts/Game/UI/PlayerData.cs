using System.Collections.Generic;
using Arkanoid.Game;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _scoreLabel;

    //[SerializeField] private TYPE _type;

    [SerializeField] private List<Heart> _hearts;

    private int _playerHp;
    private int _score;

    #endregion

    #region Properties

    public int PlayerHp => _playerHp;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _score = 0;
        _playerHp = _hearts.Count;

        Block.OnBlockDestroyed += AddScore;
        Ball.OnBallDied += LoseHeart;
    }

    private void OnDestroy()
    {
        Block.OnBlockDestroyed -= AddScore;
        Ball.OnBallDied -= LoseHeart;
    }

    #endregion

    #region Public methods

    public void LoseHeart()
    {
        Debug.Log("sosi");
        if (_hearts.Count != 0)
        {
            _hearts[_hearts.Count - 1].DestroyMe();
            _hearts.RemoveAt(_hearts.Count - 1);
        }

        _playerHp = _hearts.Count;
    }

    public void UpdateUI()
    {
        _scoreLabel.text = $"score:\n{_score}";
    }

    #endregion

    #region Private methods

    private void AddScore(int value)
    {
        _score += value;
        UpdateUI();
    }

    #endregion
}