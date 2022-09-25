using _Project.Feature;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
    public class LosePanel : MonoBehaviour, IPanel
    {
        private SoundControl _soundControl;
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        public void Show()
        {
            _soundControl.PlayLoseSound();
            gameObject.SetActive(true);
        }
    }
}