using Lean.Touch;
using UnityEngine;

namespace _Project.Feature
{
    public class CameraRotate : MonoBehaviour
    {
        public bool IsRotate;
        
        [SerializeField] private GameObject _target;
        [SerializeField] private float _horizontalSensivity;
        [SerializeField] private float _verticalSensivity;

        private Transform _cameraTransform;
        
        private void Start() => 
            _cameraTransform = transform;

        private void OnEnable() => 
            LeanTouch.OnFingerUpdate += OnFingerTouch;
        
        private void OnFingerTouch(LeanFinger finger)
        {
            if (!IsRotate || finger.IsOverGui) return;

            var swipe = finger.ScreenDelta;
            var position = _target.transform.position;
            
            _cameraTransform.RotateAround(position, Vector3.up, _horizontalSensivity * swipe.x * Time.deltaTime);
            _cameraTransform.RotateAround(position, transform.right,  _verticalSensivity * swipe.y * Time.deltaTime);
        }

        private void OnDestroy() => 
            LeanTouch.OnFingerUpdate -= OnFingerTouch;
    }
}