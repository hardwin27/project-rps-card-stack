using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [System.Serializable]
    public class CardSetProbability
    {
        [SerializeField] private float _probabilityScale;
        [SerializeField] private List<CardData> _cards = new List<CardData>();

        public float ProbabilityScale { get => _probabilityScale; }
        public CardData GetCardFromSet()
        {
            if ( _cards.Count <= 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, _cards.Count - 1);

            return _cards[randomIndex];
        }
    }

    public interface IPackData
    {
        List<CardSetProbability> CardSetProbabilities { get; }
        public int CurrentCapacity { get; }
    }
}
