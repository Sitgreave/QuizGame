using System;
using Containers;
using Game.Letter;
using Sirius.Data.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sirius.UI
{
    public class EndPanel: MonoBehaviour, IPanel
    {
        [FormerlySerializedAs("_panelContainerPrefab")] [SerializeField] private EndPanelContainer _panelContainer;
        [SerializeField] private MessageDataBundle _messageData;
        [SerializeField] private GameController _gameController;
        public GameObject PanelContainer { get; private set; }
        private void Start()
        {
            _gameController.OnLoosed += ShowLosePanel;
            _gameController.OnWined += ShowWinPanel;
            _panelContainer.RestartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            _gameController.Restart();
            Hide();
        }
        private void ShowLosePanel()
        {
            SetContent(_messageData.LosePanelContent);
            Show();
        }
        
        private void ShowWinPanel()
        {
            SetContent(_messageData.WinPanelContent);
            Show();
        }
        private void SetContent(EndPanelContent content)
        {
            _panelContainer.Fill(content);
        }

        public void Hide()
        {
            _panelContainer.gameObject.SetActive(false);
        }

        public void Show()
        {
          _panelContainer.gameObject.SetActive(true);
        }
    }
}