using DG.Tweening;
using EasyButtons;
using Lean.Touch;
using TMPro;
using UnityEngine;

namespace _Project.Feature
{
    public class ShakeText : MonoBehaviour
    {
        [Header("Shake Settings")] [SerializeField]
        private float _durationSnake, _strength;
        
        [SerializeField] private int _vibrato = 5;
        
        private TextMeshProUGUI _text;
        
        private void Awake() => 
            _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => 
            LeanTouch.OnFingerTap += Shake;
        
        private void Shake(LeanFinger obj) =>
            _text.rectTransform.DOShakeScale(_durationSnake, _strength, _vibrato, 90f, true);

        private void OnDisable() => 
            LeanTouch.OnFingerTap -= Shake;
    }
}