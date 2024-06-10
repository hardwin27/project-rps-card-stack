using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.DraggableSystem;

namespace RPSCardStack.CardSystem
{
    public interface ICardController
    {
        public string CardName { get; }
    }
}
