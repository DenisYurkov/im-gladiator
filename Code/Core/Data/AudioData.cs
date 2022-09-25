using System.Collections.Generic;
using UnityEngine;

namespace _Project.Core
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "SO/AudioData", order = 0)]
    public class AudioData : ScriptableObject
    {
        public List<AudioClip> WeaponStrikes;
        public List<AudioClip> Jerks;
        public AudioClip Win, Lose, ButtonSound, ThrowDice;
    }
}