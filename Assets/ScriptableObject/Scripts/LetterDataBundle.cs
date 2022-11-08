using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sirius.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Alphabet", menuName = "SiriusScriptableObjects/Alphabet", order = 10)]   
    public class LetterDataBundle: ScriptableObject
    {
        [SerializeField]
        
        private List<LetterContent> _letterContent;
        public List<LetterContent> LetterContent => _letterContent;

        public void FillAlphabet(char[] alphabet)
        {
            List<LetterContent> letterContent = new List<LetterContent>(alphabet.Length);
            for (int i = 0; i < alphabet.Length; i++)
            {
                LetterContent newLetter = new LetterContent(alphabet[i]);
                letterContent.Add(newLetter);
            }

            _letterContent = letterContent;
        }
    }
}