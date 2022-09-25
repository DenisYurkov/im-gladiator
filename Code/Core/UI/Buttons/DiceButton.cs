using System.Collections;
using _Project.Feature;
using EasyButtons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class DiceButton : MonoBehaviour
    {
        [SerializeField] private BoostMenu _boostMenu;
        
        private Character _player;
        private Button _diceButton;
        private SoundControl _soundControl;
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        private void Awake() => 
            _diceButton = GetComponent<Button>();
        
        private void OnEnable() => 
            _diceButton.onClick.AddListener(Press);
        
        public void SetPlayer(Character character) => 
            _player = character;

        [Button]
        private void Press() => 
            StartCoroutine(PressCoroutine());

        private IEnumerator PressCoroutine()
        {
            _soundControl.PlayButtonSound();
            _diceButton.enabled = false;
            _boostMenu.gameObject.SetActive(false);

            yield return _player.Attack();
        }

        private void OnDisable()
        {
            _diceButton.onClick.RemoveListener(Press);
            _diceButton.enabled = true;
        }
    }
}
