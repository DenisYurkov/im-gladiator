using System;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class ExitButton : IPanelButton
    {
        public void Press() => 
            Application.Quit();
    }
}