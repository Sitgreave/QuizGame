using System.Collections.Generic;
using Game.WordsPanel;
using UnityEngine;
using UnityEngine.Events;

namespace Sirius
{
    public class Quiz: MonoBehaviour
    {
        [SerializeField] private WordPanel _wordPanel;
        [SerializeField] private VirtualKeyboard _keyboard;
        
        public UnityAction OnCorrectAnswered;
        public UnityAction OnWrongAnswered;
        public UnityAction OnWordGuessed;
        private void Start()
        {
            _keyboard.OnKeyPressed += OnAnswered;
            OnWordGuessed += _keyboard.EnableAllKeys;
        }

        private void OnAnswered(LetterContent letter)
        {
            HandleAnswer(letter);
        }

        private void HandleAnswer(LetterContent letter)
        {
            List<int> lettersId = _wordPanel.TryFindLettersIds(letter);
            bool isCorrectAnswer = (lettersId != null);
            
            if(!isCorrectAnswer)
            {
                OnWrongAnswered?.Invoke();
                return;
            }
            else
            {
                OnCorrect(lettersId, letter);
            }
           
        }

        private void OnCorrect(IReadOnlyList<int> lettersId, LetterContent letter)
        {
            OnCorrectAnswered?.Invoke();
            for (int index = 0; index < lettersId.Count; index++)
            {
                _wordPanel.OpenLetter(lettersId[index]);
            }
            _keyboard.DisableKey(letter);
            
            if(_wordPanel.AllLettersOpened()) OnWordGuessed?.Invoke();
        }

   
        
        
    }
}