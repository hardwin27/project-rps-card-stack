using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class CardModel : MonoBehaviour, ICardModel
    {
        [Header("Card Data")]
        protected CardData _cardData;
        public CardData CardData { get => _cardData; }

        public void InitiateCardData(CardData cardData)
        {
            _cardData = cardData;
        }
    }
}
