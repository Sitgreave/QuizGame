using Sirius.Game.Letter;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Letter
{
    public class KeyboardLetterContainer: LetterContainer
    {
        [SerializeField] private Button _button;
        public UnityAction<KeyboardLetterContainer> OnButtonClicked;

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                OnButtonClicked?.Invoke(this);
            });
        }

        public void DisableKey()
        {
            _button.interactable = false;
        }

        public void EnableKey()
        {
            _button.interactable = true;
        }
        
        
    }
}