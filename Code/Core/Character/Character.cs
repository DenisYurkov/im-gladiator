using System.Collections;
using _Project.Extensions;
using DG.Tweening;
using UnityEngine;
using Zenject;
using static _Project.Extensions.Constants;

namespace _Project.Core
{
    public class Character : MonoBehaviour, ICharacter
    {
        [HideInInspector] 
        public int Health;
        public int AttackMultiplier = 1;
        public Transform AttackPoint;
        
        private Dice _dice;
        private DiceButton _diceButton;
        private BattleBehaviour _battleBehaviour;
        private Vector3 _originPos;
        private CharacterAnimator _characterAnimator;

        [field: SerializeField] 
        public bool IsPlayer { get; private set; }
        public bool IsAttack { get; private set;}
        public Transform NextPos { get; set; }
        public Health HealthObject { get; private set; }
        
        [Inject]
        private void Construct(Dice dice, DiceButton diceButton, BattleBehaviour battleBehaviour)
        {
            _dice = dice;
            _diceButton = diceButton;
            _battleBehaviour = battleBehaviour;
        }

        private void Awake()
        {
            PlayerPref.Init(PlayerMaxHp, 100);
            HealthObject = GetComponentInChildren<Health>();
        }

        private void Start() => 
            _characterAnimator = GetComponentInChildren<CharacterAnimator>();

        private void OnEnable()
        {
            _originPos = transform.position;

            if (!IsPlayer)
                _battleBehaviour.Characters.Add(this);
            else
            {
                if (PlayerPref.Get<int>(Constants.PlayerHp) <= 0) 
                    PlayerPref.Set((PlayerHp, PlayerPref.Get<int>(PlayerMaxHp)));
                
                Health = PlayerPref.Get<int>(Constants.PlayerHp);
            
                _battleBehaviour.Characters.Insert(0, this);
                _diceButton.SetPlayer(this);
            }
        }

        public IEnumerator Attack()
        {
            for (int i = 0; i < AttackMultiplier; i++)
            {
                _dice.gameObject.SetActive(true);
                yield return new WaitUntil(() => _dice.EndRotate);
                
                yield return Move();
                yield return MoveBack();
            }
            
            ResetMultiplier();
            _diceButton.gameObject.SetActive(false);
        }

        private void ResetMultiplier() => 
            AttackMultiplier = 1;

        private IEnumerator Move()
        {
            IsAttack = true;
            _characterAnimator.InvokeWalk();
            HealthObject.gameObject.SetActive(false);

            var tween = transform.DOMove(NextPos.position, _characterAnimator.Clip.length);
            yield return tween.WaitForCompletion();
        }

        private IEnumerator MoveBack()
        {
            IsAttack = false;
            var tween = transform.DOMove(_originPos, _characterAnimator.Clip.length)
                .OnComplete(() =>
                {
                    _characterAnimator.InvokeIdle();
                    HealthObject.gameObject.SetActive(true);

                    if (IsPlayer) 
                        _battleBehaviour.RandomEnemy();
                });
            yield return tween.WaitForCompletion();
        }
    }
}