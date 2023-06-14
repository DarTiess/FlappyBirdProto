using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIPanels
{
    public class StartMenu : PanelBase
    {
        public override event Action ClickedPanel;
        public event Action ClickedSettingsButton;
        [SerializeField] private Button settingsButton;

        private void OnEnable()
        {
            settingsButton.onClick.AddListener(OpenSettings);
        }

        private void OpenSettings()
        {
            Debug.Log("Open Settings");
            ClickedSettingsButton?.Invoke();
        }

        protected override void OnClickedPanel()
        {
           ClickedPanel?.Invoke();
        }
    }
}