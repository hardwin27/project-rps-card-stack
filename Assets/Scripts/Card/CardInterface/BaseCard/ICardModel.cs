using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface ICardModel
    {
        public CardData CardData { get; }

        public void InitiateCardData(CardData cardData);
    }
}
