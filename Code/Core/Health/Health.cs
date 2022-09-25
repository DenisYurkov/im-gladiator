using _Project.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class Health : MonoBehaviour, IHealth
    {
        private int _hpValue;
        
        private Character _character;
        private CharacterAnimator _characterAnimator;
        private BattleBehaviour _battleBehaviour;
        private Slider _healthSlider;
        private TextMeshProUGUI _hp;
        
       private int MaxValue => 
           _character.IsPlayer ? PlayerPref.Get<int>(Constants.PlayerMaxHp) : _hpValue;

       [Inject]
        private void Construct(BattleBehaviour battleBehaviour) => 
            _battleBehaviour = battleBehaviour;

        private void Awake()
        {
            _character = GetComponentInParent<Character>();
            _healthSlider = GetComponent<Slider>();
            _hp = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable() => 
            _healthSlider.gameObject.SetActive(true);

        private void Start()
        {
            _characterAnimator = _character.GetComponentInChildren<CharacterAnimator>();
            
            _hpValue = _character.Health;
            _hp.text = _hpValue.ToString();

            _healthSlider.maxValue = MaxValue;
            _healthSlider.value = _hpValue;
        }
        
        public bool CanIncreased(int increaseValue) => 
            _hpValue + increaseValue <= _healthSlider.maxValue;
        
        public void Increase(int increaseValue)
        {
            _hpValue += increaseValue;
            _hp.text = _hpValue.ToString();
            _healthSlider.value += increaseValue;
            
            PlayerPref.Increase(Constants.PlayerHp, increaseValue);
        }
        
        public void Decrease(int decreaseValue)
        {
            _hpValue -= decreaseValue;
            _hp.text = _hpValue.ToString();
            _healthSlider.value -= decreaseValue;

            if (_character.IsPlayer)
                PlayerPref.Decrease(Constants.PlayerHp, decreaseValue);

            if (_hpValue > 0) return;
            _characterAnimator.InvokeDie();
            _battleBehaviour.Characters.Remove(_character);
            gameObject.SetActive(false);
        }
        
        private void OnDisable() =>
            _healthSlider.gameObject.SetActive(false);
    }
}