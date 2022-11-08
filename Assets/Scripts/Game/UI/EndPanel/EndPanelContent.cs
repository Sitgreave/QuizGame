using System;
using Containers;
using UnityEngine;

namespace Sirius.UI
{
    [Serializable]
    public class EndPanelContent: IContent
    {
        public EndPanelContent(string message)
        {
            _message = message;
        }

       [SerializeField] private string _message;
       public string Message => _message;

    }
}