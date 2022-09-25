using _Project.Feature;
using EasyButtons;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Reaction = Animator.StringToHash("Reaction");
        private static readonly int Die = Animator.StringToHash("Die");

        private Animator _animator;
        private AnimatorClipInfo[] _animatorClipInfo;
        private Character _character;
        private SoundControl _soundControl;
        
        public AnimationClip Clip => 
            _animatorClipInfo[0].clip;
        
        [Inject]
        private void Construct(SoundControl soundControl) => 
            _soundControl = soundControl;
        
        private void Awake() => 
            _animator = GetComponent<Animator>();

        private void Start()
        {
            _character = GetComponentInParent<Character>();
            _animatorClipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        }
        
        private void StartReaction() => 
            _soundControl.PlayWeaponStrike();

        private void EndWalk()
        {
            if (_character.IsAttack)
                InvokeAttack();
        }

        [Button]
        public void InvokeIdle() => 
            _animator.SetTrigger(Idle);

        [Button]
        public void InvokeWalk()
        {
            _soundControl.PlayJerksSound();
            _animator.SetTrigger(Walk);
        }

        [Button]
        private void InvokeAttack() => 
            _animator.SetTrigger(Attack);

        [Button]
        public void InvokeReaction() => 
            _animator.SetTrigger(Reaction);

        [Button]
        public void InvokeDie()
        {
            _soundControl.PlayWeaponStrike();
            _animator.SetTrigger(Die);
        }
    }
}