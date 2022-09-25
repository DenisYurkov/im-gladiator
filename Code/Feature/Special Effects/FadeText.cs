using _Project.Core;
using _Project.Extensions;
using DG.Tweening;
using EasyButtons;
using TMPro;
using UnityEngine;

namespace _Project.Feature
{
    public class FadeText : MonoBehaviour
    {
        [SerializeField] 
        private LevelBehaviour _levelBehaviour;
        
        [Header("Shake Settings")] [SerializeField]
        private float _durationSnake, _strength;
        
        [SerializeField] private int _vibrato = 5;

        [Header("Fade Settings")] [SerializeField]
        private float _endValue, _durationFade;

        private TextMeshProUGUI _fadeProUGUI;
        
        private void Awake() => 
            _fadeProUGUI = GetComponent<TextMeshProUGUI>();

        private void Start()
        {
            var id = PlayerPref.Get<int>(Constants.LevelID) + 1;
            _fadeProUGUI.text = _levelBehaviour.CurrentLevel.IsBossFight ? "Boss!" : "Stage " + id;
            
            FadeCombine();
        }
        
        [Button]
        private void FadeCombine()
        {
            _fadeProUGUI.color = new Color(255,255,255,255);
            _fadeProUGUI.rectTransform.DOShakeScale(_durationSnake, _strength, _vibrato)
                .OnComplete(() => _fadeProUGUI.DOFade(_endValue, _durationFade));
        }
    }
}