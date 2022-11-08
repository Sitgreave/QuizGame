using System;
using Sirius.Data.ScriptableObjects;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Sirius
{
    public class Player: MonoBehaviour
    {
        [SerializeField] private GameSettingsBundle _gameSettings;
        [FormerlySerializedAs("_quizHandler")] [SerializeField] private Quiz _quiz;
        public UnityAction<int> OnLifeChanged;
        public UnityAction<int> OnScoreChanged;
        public UnityAction OnLifeEnded;
        private int _score;
        private int _lifeCount;
        private void Start()
        {
            _quiz.OnCorrectAnswered += IncreaseScore;
            _quiz.OnWrongAnswered += DecreaseLife;
            OnLifeChanged += CheckLifeCount;
            RestorePlayer();
        }

        private void IncreaseScore()
        {
            SetScore(_score + _lifeCount);
        }
        private void SetScore(int value)
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
        private void DecreaseLife()
        {
            SetLifeCount(_lifeCount - 1);
        }
        
        private void SetLifeCount(int value)
         {
             _lifeCount = value;
             OnLifeChanged?.Invoke(value);
         }

        private void CheckLifeCount(int currentLife)
         {
             if (HaveNoLife(currentLife)) OnLifeEnded?.Invoke();
         }

        
         private bool HaveNoLife(int amount)
         {
             //В условии задачи сказано "Если число попыток становится ОТРИЦАТЕЛЬНЫМ, потому не "<="
             return amount < 0;
         }

         private void RestorePlayer()
         {
             RestoreLife();
             RestoreScore();
         }

         public void RestoreLife()
         {
             SetLifeCount(_gameSettings.LifeCount);
         }

         public void RestoreScore()
         {
             SetScore(0);
         }
    }
}