using UnityEngine;

namespace Sirius.UI
{
    public interface IPanel
    {
        GameObject PanelContainer { get; }
        void Hide();
        void Show();
    }
}