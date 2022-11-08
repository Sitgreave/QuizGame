using System;
using System.Collections.Generic;
using Sirius.Data.ScriptableObjects;
using Game.Letter;
using UnityEngine;

[Serializable]
public struct Word 
{
    [SerializeField] private string _fullWord;
    public string FullWord => _fullWord;
    
    [SerializeField] private List<LetterContent> _letterContents;
    public IReadOnlyList<LetterContent> LetterContents => _letterContents;
  
    private readonly LetterFactory _letterFactory;

    public Word(string fullWord, LetterDataBundle letterDataBundle)
    {
        _fullWord = fullWord;
        _letterFactory = new LetterFactory(letterDataBundle);
        _letterContents = new List<LetterContent>(_fullWord.Length);
     
        GetLetterContent();
    }

    private void GetLetterContent()
    {
        for (int i = 0; i < FullWord.Length; i++)
        {
          
            LetterContent newContent = _letterFactory.GetLetter(FullWord[i]);
            _letterContents.Add(newContent);
        }
    }
}
