using System;
using System.Collections.Generic;
using System.Linq;
using Containers;

using Game.Letter;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.WordsPanel
{
    public class WordPanel: MonoBehaviour
    {
        [SerializeField] private HiddenLetterContainer _letterContainerPrefab;
        [SerializeField] private Transform _wordParent;
        private int _openedLettersCount;
        private ContainerIterator<HiddenLetterContainer, LetterContent> _containerIterator;
        private IReadOnlyList<HiddenLetterContainer> HiddenLetterContainers => _containerIterator.Containers;

        private void Awake()
        {
            _containerIterator = new(_letterContainerPrefab, _wordParent);
        }

        public void InsertWord(Word word)
        {
            _containerIterator.ReplaceContainers(word.LetterContents);
            _openedLettersCount = 0;
        }
        
        public List<int> TryFindLettersIds(LetterContent letter)
        {
            List<int> lettersId = new List<int>();
            for (int i = 0; i < HiddenLetterContainers.Count; i++)
            {
                if (HiddenLetterContainers[i].CurrentContent.LetterIsEqual(letter))
                {
                    lettersId.Add(i);
                }
            }
            bool lettersNotFound = lettersId.Count <= 0;
            if (lettersNotFound) return null;
            return lettersId;
        }

        public void OpenLetter(int id)
        {
            _openedLettersCount++;
            HiddenLetterContainers[id].Show();
        }

        public bool AllLettersOpened()
        {
            return _openedLettersCount >= HiddenLetterContainers.Count;
        }
    }
}