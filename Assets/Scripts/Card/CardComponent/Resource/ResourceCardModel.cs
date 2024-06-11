using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class ResourceCardModel : CardModel, IValuableModel
    {
        [SerializeField] [ReadOnly] private int _cointValue;

        public int CoinValue { get => _cointValue; }

        public void InitiateValuableData(IValuableData valuableData)
        {
            _cointValue = valuableData.CoinValue;
        }
    }
}
