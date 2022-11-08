using System;
using System.Collections.Generic;
using System.Linq;
using Sirius.Data.ScriptableObjects;
using OnEditor.RawText;
using UnityEngine;
using Random = System.Random;

namespace Game.WordsPanel
{
    public class WordIndexPool
    {
        private readonly WordIndexUtility _wordIndexUtility = new();
        private readonly WordsDataBundle _wordsData;
        private readonly Random _random = new();

        public WordIndexPool(WordsDataBundle wordsData)
        {
            _wordsData = wordsData;
        }

        // All index id, when word length more then minWordLength
        public int[] GetWordIndexPool(int minWordLength)
        {
            int[] sortedArray = IndexArray(minWordLength);
            return ShuffleArray(sortedArray);
        }

        

        private int[] IndexArray(int minWordLength)
        {
            int startIndex = _wordIndexUtility.GetFirstIndexLargerThan(minWordLength, _wordsData.Words);
            int count = _wordsData.Words.Count + 1 - startIndex;
            int[] wordIndexPool = new int[count];
            for (int i = startIndex; i < count; i++)
            {
                wordIndexPool[i] = i;
            }
            return wordIndexPool;

    
        }
        
        private T[] ShuffleArray<T>(T[] array)
        {   
            for (int i =0; i <array.Length -1; i++)
            {
                int randomIndex = _random.Next(i+1);
                (array[randomIndex], array[i]) = (array[i], array[randomIndex]);
            }

            return array;
        }
    }
}