using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPSCardStack.CardSystem
{
    public class CardView : MonoBehaviour, ICardView
    {
        [SerializeField] protected TextMeshPro _cardNameText;

        public void UpdateBaseDisplay(string name, Sprite sprite)
        {
            if (_cardNameText == null)
            {
                return;
            }

            _cardNameText.text = name;
        }
    }
}
