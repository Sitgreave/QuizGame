using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Sirius.Data.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace OnEditor.RawText
{
    public class SearchWindow : EditorWindow
    {
        private string _path = "";
        private string _text;
        
        private readonly UniqueWordsSearcher _rawTextHandler = new();
        private WordsDataBundle _wordsDataBundle;
        private LetterDataBundle _letterDataBundle;

        [MenuItem("Window/Sirius/WordSearcher")]
        public static void ShowWindow()
        {
            GetWindow<SearchWindow>("Words Searcher");
        }

        private void OnGUI()
        {
            GUILayout.Label("Select path to the text file:", EditorStyles.boldLabel);
            GUILayout.Label("Path: " + _path);
            GUILayoutOption buttonWidth = GUILayout.MaxWidth(200);
            OpenTextButton(buttonWidth);
            GUILayout.Space(25);
            GUILayout.Label("Select words data bundle to fill it later:");
            _wordsDataBundle = EditorGUILayout.ObjectField("WordsDataBundle", _wordsDataBundle, typeof(WordsDataBundle), true) as WordsDataBundle;
            _letterDataBundle = EditorGUILayout.ObjectField("LettersDataBundle", _letterDataBundle, typeof(LetterDataBundle), true) as LetterDataBundle;
            CreateUniqueWordsButton(buttonWidth);
         
        }
        
        private void OpenTextButton(GUILayoutOption option)
        {
            if (GUILayout.Button("Browse...", option))
            {
                _path = EditorUtility.OpenFilePanel("Text file", Application.dataPath, "txt");
            }
        }

        private async void CreateUniqueWordsButton(GUILayoutOption option)
        {
            if (!GUILayout.Button("Fill", option)) return;
            if (_wordsDataBundle == null){
                EditorUtility.DisplayDialog("Error", "Firstly you need to select words bundle.", "Okay...");
                return;
            }
            
            if (!File.Exists(_path))
            {
                EditorUtility.DisplayDialog("Error", "Invalid text path", "OK");
                return;
            }
            _text = await GetTextFromPath();
            if (_text == null) return;
            InitializeWordsBundle();
            EditorUtility.DisplayDialog("Success", "Selected bundle has been successfully filled.", "Great!");
        }

        private void InitializeWordsBundle()
        {
            List<string> fullWords = _rawTextHandler.GetUniqueWords(_text);
            List<Word> words = new(fullWords.Count);
            for (int i = 0; i < fullWords.Count; i++)
            {
                Word word = new(fullWords[i], _letterDataBundle);
                words.Add(word);
            }
            EditorUtility.SetDirty(_wordsDataBundle);
            _wordsDataBundle.InitializeWords(words);
        }
        
        private Task<string> GetTextFromPath()
        {
            if (File.Exists(_path)) return File.ReadAllTextAsync(_path);
            else throw new Exception("Invalid text path");
        }

       
        
        
    }
}