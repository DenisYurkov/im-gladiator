using System.Collections;
using _Project.Feature;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Core
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private Ease _diceCurve;
        [SerializeField] private DiceRay _diceRay;

        private SoundControl _soundControl;
        private readonly float[] _posX = {0, 90, 180, 360};
        private readonly float[] _posY = {0, 90, 180, 360};
        private readonly float[] _posZ = {0, 90, 180};
        
        private Vector3 RandomVector => new(_posX[Random.Range(0, _posZ.Length)],
            _posY[Random.Range(0, _posZ.Length)], _posZ[Random.Range(0, _posZ.Length)]);

        public bool EndRotate { get; private set; }
        public int SideValue { get; private set; }
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;

        private void OnEnable()
        {
            Rotate();
            EndRotate = false;
        }

        private void Rotate()
        {
            _soundControl.PlayDiceSound();
            transform.DORotate(RandomVector, 1f)
                .SetEase(_diceCurve)
                .OnComplete(() => { StartCoroutine(DiceDisable()); });
        }

        private IEnumerator DiceDisable()
        {
            SideValue = _diceRay.GetNumber();
            yield return new WaitForSeconds(0.3f);
            
            _diceRay.ResetMultiplier();
            gameObject.SetActive(false);
        }
 
        private void OnDisable()
        {
            transform.rotation = Quaternion.identity;
            EndRotate = true;
        }
    }
}