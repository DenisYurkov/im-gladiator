using _Project.Extensions;
using _Project.Feature;
using Gadget.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class SkinButton : MonoBehaviour
    {
        [SerializeReference, ReferenceTypeSelector]
        private Skin _skin;

        [SerializeField] 
        private TextMeshProUGUI _cost;
        
        private Button _button;
        private SoundControl _soundControl;
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        private void Awake() => 
            _button = GetComponent<Button>();

        private void Start()
        {
            _cost.text = _skin.Cost.ToString();
            
            if (PlayerPref.Get<int>(Constants.IsSkinBuying + _skin.ID) == 1)
            {
                _skin.LockObject.SetActive(false);
                _skin.SkinObject.SetActive(true);
            }
        }

        private void OnEnable() => 
            _button.onClick.AddListener(() =>
            {
                _soundControl.PlayButtonSound();
                _skin.TryBuying();
                _skin.Select();
            });

        private void OnDisable() =>
            _button.onClick.RemoveListener(() =>
            {
                _skin.TryBuying();
                _skin.Select();
            });
    }
}