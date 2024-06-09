using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPSCardStack.CardSystem
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _cardNameTextUi;

        public void UpdateCardName(string name)
        {
            if (_cardNameTextUi == null)
            {
                return;
            }

            _cardNameTextUi.text = name;
        }
    }
}
