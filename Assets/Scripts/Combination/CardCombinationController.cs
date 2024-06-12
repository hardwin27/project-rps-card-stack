using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.CardSystem;

namespace RPSCardStack.CombinationSystem
{
    public class CardCombinationController : MonoBehaviour
    {
        [SerializeField] private CardController _cardController;
        private CombinationManager _combinationManager;

        private void Start()
        {
            _combinationManager = CombinationManager.Instance;
        }

        private void OnEnable()
        {
            if (_cardController != null)
            {
                _cardController.CardStacked += HandleCardStacked;
                _cardController.CardUnstacked += HandleCardUnstacked;
            }
        }

        private void OnDisable()
        {
            if (_cardController != null)
            {
                _cardController.CardStacked -= HandleCardStacked;
                _cardController.CardUnstacked -= HandleCardUnstacked;
            }
        }

        private void HandleCardStacked()
        {
            _combinationManager.CheckStack(_cardController);
        }

        private void HandleCardUnstacked()
        {
            _combinationManager.CheckUnstack(_cardController);
        }
    }
}
