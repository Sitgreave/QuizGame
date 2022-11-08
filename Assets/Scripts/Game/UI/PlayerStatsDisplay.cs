using System;
using TMPro;
using UnityEngine;

namespace Sirius.UI
{
    public class PlayerStatsDisplay: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _lifeText;

        private void Start()
        {
            _player.OnLifeChanged += UpdateLifeText;
            _player.OnScoreChanged += UpdateScoreText;
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void UpdateLifeText(int life)
        {
            _lifeText.text = life.ToString();
        }
    }
}