using System;
using Sirius.Data.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Game.WordsPanel
{
    public class WordPanelHandler: MonoBehaviour
    {
        [SerializeField] private WordPanel _wordPanel;
        [SerializeField] private GameSettingsBundle _gameSettings;
        [SerializeField] private WordsDataBundle _wordsData;
        private WordFactory _wordFactory;
        private WordIndexPool _indexPool;
        private int[] _indexList;
        private int _currentWordIndex = 0;

        public UnityAction OnWordsEnded;
        private bool WordsIsEnded => _currentWordIndex >= _indexList.Length;

        private void Awake()
        {
            _indexPool = new WordIndexPool(_wordsData);
            _wordFactory = new WordFactory(_wordsData);
        }
        
        public void InsertNewWord()
        {
            if (WordsIsEnded){
                OnWordsEnded?.Invoke();
                return;
            }
            
            _wordPanel.InsertWord(_wordFactory.GetWord(_indexList[_currentWordIndex]));
            _currentWordIndex++;
        }
        
        public void IndexRandomize()
        {
           _indexList = _indexPool.GetWordIndexPool(_gameSettings.MinWordLength);
           _currentWordIndex = 0;
        }
    }
}