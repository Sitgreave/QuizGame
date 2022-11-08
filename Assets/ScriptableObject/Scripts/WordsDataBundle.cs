using System.Collections.Generic;
using UnityEngine;

namespace Sirius.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Words Bundle", menuName = "SiriusScriptableObjects/Words", order = 10)]   
    public class WordsDataBundle: ScriptableObject
    {
       [SerializeField] private List<Word> _words;
        public IReadOnlyList<Word> Words => _words;

        public void InitializeWords(List<Word> words)
        {
            _words = words;
        }
    }
}