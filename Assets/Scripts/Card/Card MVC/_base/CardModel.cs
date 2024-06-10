using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class CardModel : MonoBehaviour, ICardModel
    {
        [Header("Card Data")]
        [SerializeField] [ReadOnly] protected string _cardName;
        
        public virtual string CardName { get; }

        public virtual Sprite CardSprite { get; }

        public void InitiateCardData(ICardData cardData)
        {
            
        }
    }
}
