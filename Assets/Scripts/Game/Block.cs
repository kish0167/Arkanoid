using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Sprite _conditionSprite0;
        [SerializeField] private Sprite _conditionSprite1;
        [SerializeField] private Sprite _conditionSprite2;
        [Header("-_-")]
        [SerializeField] private SpriteRenderer _thisBlockSpriteRenderer;

        [Header("block prefs")]
        [SerializeField] private uint _startHp;

        [SerializeField] private int _scoreValue;

        private int _hp;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _hp = (int)_startHp;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 1)
            {
                ScoreTracker.Score += _scoreValue;
                Destroy(gameObject);
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