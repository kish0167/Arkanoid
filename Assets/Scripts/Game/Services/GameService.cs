using System;
using Arkanoid.Game;
using UnityEngine;

public class GameService : MonoBehaviour
{
    #region Variables

    [SerializeField] private PlayerData _playerData;

    #endregion

    #region Events

    public static event Action Respawn;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Ball.OnBallDied += CheckEndOfHealth;
    }

    private void OnDestroy()
    {
        Ball.OnBallDied -= CheckEndOfHealth;
    }

    #endregion

    #region Private methods

    private void CheckEndOfHealth()
    {
        if (_playerData.PlayerHp != 1)
        {
            Respawn?.Invoke();
        }
        //TODO: Game over screen
    }

    #endregion
}