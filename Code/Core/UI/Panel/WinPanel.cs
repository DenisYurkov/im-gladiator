using _Project.Feature;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core
{
    public class WinPanel : MonoBehaviour, IPanel
    { 
        [SerializeField] private LevelBehaviour _levelBehaviour;
        [SerializeField] private Money _money;
        [SerializeField] private Text _numberOfCoin;
        
        private SoundControl _soundControl;

        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        public void Show()
        {
            _soundControl.PlayWinSound();
            gameObject.SetActive(true);
            
            _numberOfCoin.text = _levelBehaviour.CurrentLevel.MoneyPerLevel.ToString();
            _money.OnIncrease.Invoke(_levelBehaviour.CurrentLevel.MoneyPerLevel);
        }
    }
}