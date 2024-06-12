using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface IValuableController
    {
        public int CoinValue { get; }

        public void SetValuableData(IValuableData valuableData);
    }
}
