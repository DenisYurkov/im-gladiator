using UnityEngine;
using Zenject;

namespace _Project.Core
{
    public class HealthStealer : MonoBehaviour
    {
        [SerializeField] private LayerMask _checkLayer;

        private Health _health;
        private Dice _dice;
        private CharacterAnimator _characterAnimator;

        [Inject]
        public void Construct(Dice dice) => 
            _dice = dice;
        
        private void Awake() => 
            _health = GetComponentInChildren<Health>();

        private void Start() => 
            _characterAnimator = GetComponentInChildren<CharacterAnimator>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character _) && 1 << other.gameObject.layer == _checkLayer)
            {
                if (other.GetComponent<Character>().IsAttack)
                {
                    _characterAnimator.InvokeReaction();
                    _health.Decrease(_dice.SideValue);
                }
            }
        }
    }
}