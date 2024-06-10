using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface ICardModel
    {
        public string CardName { get; }
        public Sprite CardSprite { get; }

        public void InitiateCardData(ICardData cardData);
    }
}
