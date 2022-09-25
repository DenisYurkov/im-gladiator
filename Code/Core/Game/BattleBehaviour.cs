using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core
{
    public class BattleBehaviour : MonoBehaviour
    {
        public List<Character> Characters;
        
        [SerializeField] private DiceButton _diceButton;
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private BoostMenu _boostMenu;
        
        private int _attackerIndex;
        private int _random;
        private readonly WaitForSeconds _waitAfterEnd = new(1f);
        private Coroutine _coroutine;

        private void Start()
        {
            for (int i = 1; i < Characters.Count; i++) 
                Characters[i].NextPos = Characters[0].AttackPoint;

            if (Application.isMobilePlatform)
            {
                Application.targetFrameRate = 60;
                QualitySettings.vSyncCount = 0;
            }
            _coroutine = StartCoroutine(NextMove());
        }

        private IEnumerator NextMove()
        {
            for (_attackerIndex = 0; _attackerIndex < Characters.Count; _attackerIndex++)
            {
                if (Characters[_attackerIndex].IsPlayer == false)
                    yield return Characters[_attackerIndex].Attack();
                else
                {
                    ActivateUI();
                    RandomEnemy();
                    yield return new WaitUntil(PlayerEndAttack);
                }
            }
            StartCoroutine(DeterminateWinner());
        }

        private bool PlayerEndAttack() => 
            _diceButton.gameObject.activeSelf == false || Characters.Count == 1;

        private void ActivateUI()
        {
            _boostMenu.gameObject.SetActive(true);
            _diceButton.gameObject.SetActive(true);
        }

        public void RandomEnemy()
        {
            _random = Extensions.Random.GetNumber(1, Characters.Count);
            Characters[_attackerIndex].NextPos = Characters[_random].AttackPoint;
        }

        private IEnumerator DeterminateWinner()
        {
            switch (Characters[0].IsPlayer)
            {
                case false:
                    yield return _waitAfterEnd;
                    _losePanel.Show();
                    StopCoroutine(_coroutine);
                    break;
                case true when Characters.Count == 1:
                    yield return _waitAfterEnd;
                    _winPanel.Show();
                    StopCoroutine(_coroutine);
                    break;
                default:
                    _coroutine = StartCoroutine(NextMove());
                    break;
            }
        }
    }
}