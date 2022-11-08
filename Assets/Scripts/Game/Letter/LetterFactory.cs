using System.Linq;
using Sirius.Data.ScriptableObjects;
using UnityEngine;

namespace Game.Letter
{
    public class LetterFactory
    {
        private readonly LetterDataBundle _letterData;

        public LetterFactory(LetterDataBundle letterData)
        {
            _letterData = letterData;
        }

        public LetterContent GetLetter(char symbol)
        {
            return _letterData.LetterContent.FirstOrDefault(letter => letter.Symbol == symbol);
        }
    }
}