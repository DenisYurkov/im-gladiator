using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core
{
    public class BoostMenu : MonoBehaviour
    {
        private Button _button;
        private RectTransform _rectTransform;

        private Vector2 _anchoredPosDefault;
        private readonly Vector2 _anchoredPosTo = new(478, 0);

        private bool _isPress;
        
        private void Awake()
        {
            _anchoredPosDefault = GetComponent<RectTransform>().anchoredPosition;
            _button = GetComponent<Button>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable() => 
            _button.onClick.AddListener(PressControl);

        private void PressControl()
        {
            if (_isPress == false)
            {
                _rectTransform.DOAnchorPos(_anchoredPosTo, 1f);
                _isPress = true;
            }
            else
            {
                _rectTransform.DOAnchorPos(_anchoredPosDefault, 1f);
                _isPress = false;
            }
        }

        private void OnDisable() => 
            _button.onClick.RemoveListener(PressControl);
    }
}
