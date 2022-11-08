using System;
using System.Collections.Generic;
using System.Linq;
using Sirius.Data.ScriptableObjects;
using OnEditor.RawText;
using UnityEngine;
using Random = System.Random;


namespace Game.WordsPanel
{
    public class WordFactory
    {
        private readonly WordsDataBundle _wordsData;
        
        public WordFactory(WordsDataBundle wordsData)
        {
            _wordsData = wordsData;
        }

        public Word GetWord(int index)
        { 
            Word word = _wordsData.Words[index];
            return word;
        }
        
        
    }
}