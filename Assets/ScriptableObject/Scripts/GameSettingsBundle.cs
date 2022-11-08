using UnityEngine;

namespace Sirius.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Settings Bundle", menuName = "SiriusScriptableObjects/GameSettings", order = 10)]   
    public class GameSettingsBundle: ScriptableObject
    {
        [SerializeField] private int _minWordLength;
        [SerializeField] private int _lifeCount;
        public int MinWordLength => _minWordLength;
        public int LifeCount => _lifeCount;
    }
}