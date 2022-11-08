using System;
using Game.WordsPanel;
using Sirius.Data.ScriptableObjects;
using Sirius.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Sirius
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private WordPanelHandler _wordPanelHandler;
        [SerializeField] private Player _player;
        [SerializeField] private Quiz _quiz;
        public UnityAction OnLoosed;
        public UnityAction OnWined;
        private void Start()
        {
            StartQuiz();
            _wordPanelHandler.OnWordsEnded += OnWined;
            _player.OnLifeEnded += Lose;
            _quiz.OnWordGuessed += NextWord;
        }

        private void StartQuiz()
        {
            _wordPanelHandler.IndexRandomize();
            _wordPanelHandler.InsertNewWord();
        }

        private void Lose()
        {
          OnLoosed.Invoke();
        }

        private void Win()
        {
            OnWined.Invoke();
        }
        
        public void Restart()
        {
            _player.RestoreLife();
            _player.RestoreScore();
            StartQuiz();
        }

        private void NextWord()
        {
            _player.RestoreLife();
            _wordPanelHandler.InsertNewWord();
        }
        
        
    }
}