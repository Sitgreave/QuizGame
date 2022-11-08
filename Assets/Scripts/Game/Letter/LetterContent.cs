using System;
using Containers;
using UnityEngine;

[Serializable]
public class LetterContent: IContent
{
    public char Symbol => _symbol;
    [SerializeField] private char _symbol;
    
     public LetterContent(char symbol) 
     {
         _symbol = symbol;
     }
     
     public bool LetterIsEqual(LetterContent content)
     {
         return content.Symbol == _symbol;
     }
}
