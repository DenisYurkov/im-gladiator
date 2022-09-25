using _Project.Feature;
using EasyButtons;
using Gadget.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class BoostButton : MonoBehaviour
    {
        [SerializeReference, ReferenceTypeSelector]
        private Boost _boost;

        [SerializeField] 
        private TextMeshProUGUI _cost;
        
        private Button _button;
        private SoundControl _soundControl;
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        private void Awake() => 
            _button = GetComponent<Button>();

        private void OnEnable() => 
            _button.onClick.AddListener(Press);
        
        private void Start() => 
            _cost.text = _boost.Cost.ToString();

        [Button]
        private void Press()
        {
            _soundControl.PlayButtonSound();
            _boost.TryApply();
        }

        private void OnDisable() => 
            _button.onClick.RemoveListener(Press);

    }
}