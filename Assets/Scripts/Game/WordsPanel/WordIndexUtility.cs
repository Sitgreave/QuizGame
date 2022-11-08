using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnEditor.RawText
{
    public class WordIndexUtility
    {
        private Queue<int> _lengthIncreaseId;
        
        //Get first id from the queue, where word length more then input.
        public int GetFirstIndexLargerThan(int value, IReadOnlyList<Word> words)
        {
            if(_lengthIncreaseId == null) _lengthIncreaseId = GetLengthIndexQueue(words);
           
            Queue<int> queueTemp = new(_lengthIncreaseId);
            while (queueTemp.Count > 0)
            {
                int index = queueTemp.Dequeue();
                int length = words[index].FullWord.Length;

                if (length < value) continue;
                return index;
            }

            throw new Exception("Incorrect input data");
        }

        //The queue, when writing every ID, where word length increased. Working only with length-SORTED array.
        private Queue<int> GetLengthIndexQueue(IReadOnlyList<Word> words)
        {
            Queue<int> fullIndexQueue = new(words.Count);
            int temp = -1;
            for (int i = 0; i < words.Count; i++)
            {
                if (temp >= words[i].FullWord.Length) continue;
                temp = words[i].FullWord.Length;
                fullIndexQueue.Enqueue(i);
            }
          
            return fullIndexQueue;
        }
    }
}