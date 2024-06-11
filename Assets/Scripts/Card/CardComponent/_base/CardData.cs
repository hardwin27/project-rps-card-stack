using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Card Data/Base")]
    public class CardData : ScriptableObject, ICardData
    {
        [Header("Card Data")]
        [SerializeField] protected string _cardName;
        [SerializeField] protected Sprite _cardSprite;

        public string CardName { get => _cardName; }
        public Sprite CardSprite { get => _cardSprite; }
    }
}
