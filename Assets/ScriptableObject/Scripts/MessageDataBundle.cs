using Sirius.UI;
using UnityEngine;

namespace Sirius.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Message Bundle", menuName = "SiriusScriptableObjects/MessageData", order = 10)]  
    public class MessageDataBundle: ScriptableObject
    {
        [SerializeField] private EndPanelContent _losePanelContent;
        public EndPanelContent LosePanelContent => _losePanelContent;
        [SerializeField] private EndPanelContent _winPanelContent;
        public EndPanelContent WinPanelContent => _winPanelContent;

    }
}