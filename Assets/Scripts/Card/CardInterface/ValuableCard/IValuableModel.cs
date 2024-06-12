using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface IValuableModel
    {
        public int CoinValue { get; }

        public void InitiateValuableData(IValuableData valuableData);
    }
}
