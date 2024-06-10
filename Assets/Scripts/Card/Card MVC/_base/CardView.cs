using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPSCardStack.CardSystem
{
    public class CardView : MonoBehaviour, ICardView
    {
        [SerializeField] protected TextMeshPro _cardNameTextUi;

        public void UpdateBaseDisplay(string name, Sprite sprite)
        {
            if (_cardNameTextUi == null)
            {
                return;
            }

            _cardNameTextUi.text = name;
        }
    }
}
