using System.Collections.Generic;
using System.Linq;
using Containers;
using Game.Letter;
using Sirius.Data.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Sirius
{
    public class VirtualKeyboard: MonoBehaviour
    {
        
        [SerializeField] private LetterDataBundle _letterData;
        [SerializeField] private KeyboardLetterContainer _containerPrefab;
        [SerializeField] private Transform _keyBoardParent;

        private ContainerIterator<KeyboardLetterContainer, LetterContent> _containerIterator;
        private IReadOnlyList<KeyboardLetterContainer> _containers => _containerIterator.Containers;
        public UnityAction<LetterContent> OnKeyPressed;
        private void Start()
        {
            _containerIterator = new(_containerPrefab, _keyBoardParent);
            SpawnAlphabetKey();
        }

        private void SpawnAlphabetKey()
        {
            _containerIterator.ReplaceContainers(_letterData.LetterContent);
            for (int i = 0; i < _containers.Count; i++)
            {
                _containers[i].OnButtonClicked += KeyInvoke;
            }
        }

        private void KeyInvoke(KeyboardLetterContainer content)
        {
            OnKeyPressed.Invoke(content.CurrentContent);
        }
        
        public void DisableKey(LetterContent content)
        {
            FindLetter(content).DisableKey();
        }
        
        private KeyboardLetterContainer FindLetter(LetterContent content)
        {
            return _containers
                .FirstOrDefault(
                    myContent => myContent.CurrentContent.LetterIsEqual(content)
                );
        }

        public void EnableAllKeys()
        {
            for (int i = 0; i < _containers.Count; i++)
            {
                _containerIterator.Containers[i].EnableKey();
            }
        }
       
       
    }
}