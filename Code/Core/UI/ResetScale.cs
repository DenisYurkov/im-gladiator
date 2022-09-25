using UnityEngine;

namespace _Project.Core
{
    public class ResetScale : MonoBehaviour
    {
        [SerializeField] private Vector3 _scale;
    
        private RectTransform _rectTransform;

        private void Awake() => 
            _rectTransform = GetComponent<RectTransform>();

        private void Start()
        {
            if (Application.isMobilePlatform || Application.isEditor) return;
            _rectTransform.localScale = _scale;
        }
    }
}
