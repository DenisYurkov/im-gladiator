using System;
using _Project.Feature;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class CloseButton : IPanelButton
    {
        [SerializeField] private GameObject _screen;
        [SerializeField] private CameraRotate _cameraRotate;
        
        public void Press()
        {
            _cameraRotate.IsRotate = true;
            _screen.gameObject.SetActive(false);
        }
    }
}
