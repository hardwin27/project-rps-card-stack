using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [CreateAssetMenu(fileName = "FormulaData", menuName = "Card Formula Data")]
    public class CardFormulaData : ScriptableObject
    {
        [SerializeField] private CardData _resultCard;
        [SerializeField] private List<CardData> _requiredCards;
        [SerializeField] private float _timeReq;
        [SerializeField] private bool _isOrderExact;
        [SerializeField] private List<CardData> _destroyedCards;

        public CardData ResultCard { get => _resultCard; }
        public List<CardData> RequiredCards { get => _requiredCards; }
        public float TimeReq { get => _timeReq; }
        public bool IsOrderExact { get => _isOrderExact; }
        public List<CardData> DestroyedCard { get => _destroyedCards; }
    }
}
