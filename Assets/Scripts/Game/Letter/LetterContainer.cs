using Containers;
using TMPro;
using UnityEngine;

namespace Sirius.Game.Letter
{
    public abstract class LetterContainer: Container<LetterContent>
    {
        [SerializeField] protected TMP_Text _letterText;
        protected override void Set(LetterContent item)
        {
            _letterText.text = item.Symbol.ToString();
        }

       
    }
}