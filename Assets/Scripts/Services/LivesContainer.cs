using System.Collections.Generic;
using Arkanoid.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Services
{
    public class HpBarService : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Heart _heartPrefab;

        private readonly List<Heart> _hearts = new();


        private HorizontalLayoutGroup _heartrsContainer;
        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Heart.OnCreated += HeartCreatedCallback;
        }

        private void Start()
        {
            GameService.Instance.OnLivesChanged += LivesChangedCallback;
            _heartrsContainer = FindObjectOfType<HorizontalLayoutGroup>();
        }

        private void OnDestroy()
        {
            Heart.OnCreated -= HeartCreatedCallback;
            GameService.Instance.OnLivesChanged -= LivesChangedCallback;
        }

        #endregion

        #region Public methods

        public void LivesChangedCallback()
        {
            ShowNHearts(GameService.Instance.Lives);
        }

        #endregion

        #region Private methods

        private Heart GetFirstHeart()
        {
            if (_hearts.Count == 0)
            {
                return null;
            }

            return _hearts[0];
        }

        private void HeartCreatedCallback(Heart obj)
        {
            if (_hearts.Contains(obj))
            {
                return;
            }

            _hearts.Add(obj);
        }

        private void ShowNHearts(int n)
        {
            if (_hearts.Count == n || n < 0)
            {
                return;
            }

            if (_hearts.Count > n)
            {
                _hearts[^1].DestroyMe();
                _hearts.RemoveAt(_hearts.Count - 1);
                ShowNHearts(n);
            }
            else
            {
                Heart newHeart = Instantiate(_heartPrefab, _heartrsContainer.transform);
                _hearts.Add(newHeart);
                ShowNHearts(n);
            }
        }

        #endregion
    }
}