using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace OnEditor.RawText
{
    public class UniqueWordsSearcher
    {
        public List<string> GetUniqueWords(string fullText)
        {
            List<string> wordArray = GetWordArray(fullText);
            List<string> clearedWordArray = SingleLetterWordCleaning(wordArray);
            List<string> uniqueList = SearchAndSortUniqueWords(clearedWordArray);

            return uniqueList;
        }


        private List<string> GetWordArray(string text)
        {
            char[] delimiterChars =  {
                ' ', ',', '.', 
                '\t', '\n','\r', 
                ':', '!', '?', 
                '(', ')', ';', 
                '`', '-', '"',
                '*'
            };
           
            List<string> words = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            return words;
        }

        private List<string> SingleLetterWordCleaning(IReadOnlyList<string> words)
        {
            List<string> clearWords = new(words.Count);
            string[] delimiterNums =
            {
                "A", "I"
            };


            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                
                if (words[i].Length == 1)
                {
                    if (!IsSingleLetterWord(delimiterNums, word)) continue;
                }
                clearWords.Add(word.ToUpper());
            }

            return clearWords;
        }

        private bool IsSingleLetterWord(IReadOnlyList<string> dumpChars, string word)
        {
            const int singleLetterWordLength = 1;
            if (word.Length == singleLetterWordLength)
            {
                for (int index = 0; index < dumpChars.Count; index++)
                {
                    string t = dumpChars[index];
                    if (word == t) return true;
                }
            }

            return false;
        }

        private List<string> SearchAndSortUniqueWords(IReadOnlyCollection<string> words)
        {
            if (words == null)
                throw new Exception();
            else
            {
                IOrderedEnumerable<string> sortedElements = 
                    from arrElement in words.Distinct()
                    orderby arrElement.Length
                    select arrElement;
                return sortedElements.ToList();
            }
        }

     
    }
}
