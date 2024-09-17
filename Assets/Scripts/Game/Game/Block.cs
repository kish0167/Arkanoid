using System;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [Header("Sprites")]
        [SerializeField] private Sprite _conditionSprite0;
        [SerializeField] private Sprite _conditionSprite1;
        [SerializeField] private Sprite _conditionSprite2;
        [Header("-_-")]
        [SerializeField] private SpriteRenderer _thisBlockSpriteRenderer;

        [Header("block prefs")]
        [SerializeField] private uint _startHp;

        [SerializeField] private int _scoreValue;

        [SerializeField] private bool _undestructable;

        [SerializeField] private bool _transparent;

        private int _hp;

        private bool _isVisible;

        #endregion

        #region Events

        public static event Action<int> OnBlockDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _hp = (int)_startHp;

            if (_transparent && !_isVisible)
            {
                _thisBlockSpriteRenderer.sprite = null;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_transparent && !_isVisible)
            {
                _isVisible = true;
                UpdateSprite();
                return;
            }

            if (_undestructable)
            {
                return;
            }

            if (_hp <= 1)
            {
                Destroy(gameObject);
                OnBlockDestroyed?.Invoke(_scoreValue);
                return;
            }

            _hp--;

            UpdateSprite();
        }

        #endregion

        #region Private methods

        private void UpdateSprite()
        {
            if (_hp > _startHp * 2 / 3)
            {
                _thisBlockSpriteRenderer.sprite = _conditionSprite0;
                return;
            }

            if (_hp > _startHp / 3)
            {
                _thisBlockSpriteRenderer.sprite = _conditionSprite1;
                return;
            }

            _thisBlockSpriteRenderer.sprite = _conditionSprite2;
        }

        #endregion
    }
}