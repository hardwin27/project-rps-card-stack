using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(CardController))]
    public class CardDataAssigner : MonoBehaviour
    {
        [SerializeField] private CardData _cardData;

        private CardController _cardController;

        private void Awake()
        {
            _cardController = GetComponent<CardController>();
        }

        private void Start()
        {
            if (_cardData != null)
            {
                _cardController.SetCardData(_cardData);
            }
        }
    }
}
