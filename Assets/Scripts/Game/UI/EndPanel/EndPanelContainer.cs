using Containers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sirius.UI
{
    public class EndPanelContainer: Container<EndPanelContent>
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _restartButton;
        public Button RestartButton => _restartButton;
        protected override void Set(EndPanelContent item)
        {
            _text.text = item.Message;
        }
    }
}