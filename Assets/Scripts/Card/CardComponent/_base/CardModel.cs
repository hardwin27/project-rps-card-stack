using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class CardModel : MonoBehaviour, ICardModel
    {
        [Header("Card Data")]
        [SerializeField] [ReadOnly] private string _cardName;
        [SerializeField] [ReadOnly] private Sprite _cardSprite;
        
        public virtual string CardName { get => _cardName; }

        public virtual Sprite CardSprite { get => _cardSprite; }

        public void InitiateCardData(ICardData cardData)
        {
            _cardName = cardData.CardName;
            _cardSprite = cardData.CardSprite;
        }
    }
}
