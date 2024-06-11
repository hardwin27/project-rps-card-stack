using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [CreateAssetMenu(fileName = "ResourceData", menuName = "Card Data/Resource Data")]
    public class ResourceCardData : CardData, IValuableData
    {
        [SerializeField] protected int _coinValue;
        public int CoinValue { get => _coinValue; }
    }
}
