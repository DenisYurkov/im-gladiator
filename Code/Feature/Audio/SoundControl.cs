using _Project.Core;
using EasyButtons;
using UnityEngine;
using Random = _Project.Extensions.Random;

namespace _Project.Feature
{
    public class SoundControl : MonoBehaviour
    { 
        [SerializeField] private AudioData _audioData;
        [SerializeField] private AudioSource _audioSource;

        [Button]
        public void PlayWeaponStrike() =>
            _audioSource.PlayOneShot(_audioData.WeaponStrikes[Random.GetNumber(0, _audioData.WeaponStrikes.Count)]);

        [Button]
        public void PlayJerksSound() => 
            _audioSource.PlayOneShot(_audioData.Jerks[Random.GetNumber(0, _audioData.Jerks.Count)]);
        
        [Button]
        public void PlayWinSound() => 
            _audioSource.PlayOneShot(_audioData.Win);
        
        [Button]
        public void PlayLoseSound() => 
            _audioSource.PlayOneShot(_audioData.Lose);

        [Button]
        public void PlayButtonSound() => 
            _audioSource.PlayOneShot(_audioData.ButtonSound);

        [Button]
        public void PlayDiceSound() => 
            _audioSource.PlayOneShot(_audioData.ThrowDice);
    }
}