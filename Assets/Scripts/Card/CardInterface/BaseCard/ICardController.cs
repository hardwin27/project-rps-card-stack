using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.DraggableSystem;

namespace RPSCardStack.CardSystem
{
    public interface ICardController
    {
        public CardData CardData { get; }

        public void SetCardData(CardData cardData);
    }
}
