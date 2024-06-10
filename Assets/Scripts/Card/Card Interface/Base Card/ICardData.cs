using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface ICardData
    {
        public string CardName { get; }
        public Sprite CardSprite { get; }
    }
}
