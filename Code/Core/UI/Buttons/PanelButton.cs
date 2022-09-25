using _Project.Feature;
using Gadget.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class PanelButton : MonoBehaviour
    {
        [SerializeReference, ReferenceTypeSelector]
        private IPanelButton _panelButton;
        
        private SoundControl _soundControl;
        private Button _button;

        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;

        private void Awake() => 
            _button = GetComponent<Button>();

        private void OnEnable()
        {
            _button.onClick.AddListener(() =>
            {
                _soundControl.PlayButtonSound();
                _panelButton.Press();
            });
        }

        private void OnDisable() => 
            _button.onClick.RemoveListener(_panelButton.Press);
    }
}