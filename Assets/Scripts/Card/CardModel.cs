using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public class CardModel : MonoBehaviour
    {
        [SerializeField] private string _cardName;

        public string CardName { get => _cardName; }
    }
}
