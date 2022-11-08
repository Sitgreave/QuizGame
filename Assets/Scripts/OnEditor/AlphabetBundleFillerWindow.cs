using Sirius.Data.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace OnEditor.RawText
{
    public class AlphabetBundleFillerWindow : EditorWindow
    {
        private LetterDataBundle _letterDataBundle;

        private readonly char[] _englishAlphabet = new char[] { 
          'Q','W','E','R','T', 'Y', 'U','I', 'O','P',
          'A','S','D', 'F', 'G', 'H','J','K','L','\'',
          'Z','X','C','V','B','N','M'
        };

        [MenuItem("Window/Sirius/AlphabetFiller")]
        public static void ShowWindow()
        {
            GetWindow<AlphabetBundleFillerWindow>("AlphabetBundleFiller");
        }
        
        private void OnGUI()
        {
            GUILayoutOption buttonWidth = GUILayout.MaxWidth(200);
            GUILayout.Space(25);
            GUILayout.Label("Select letters data bundle to fill it:");
            _letterDataBundle = EditorGUILayout.ObjectField("LettersDataBundle", _letterDataBundle, typeof(LetterDataBundle), true) as LetterDataBundle;
            FillAlphabetButton(buttonWidth);
         
        }
        
        private void FillAlphabetButton(GUILayoutOption option = null)
        {
            if (GUILayout.Button("Fill", option))
            {
                if (_letterDataBundle != null)
                {
                    EditorUtility.SetDirty(_letterDataBundle);
                    _letterDataBundle.FillAlphabet(_englishAlphabet);
                    EditorUtility.DisplayDialog("Success", "Alphabet bundle has been successfully filled", "Yeap!");
                }
                else 
                    EditorUtility.DisplayDialog("Error", "Firstly you need to select bundle", "Okay...");
            }
        }
    }
}