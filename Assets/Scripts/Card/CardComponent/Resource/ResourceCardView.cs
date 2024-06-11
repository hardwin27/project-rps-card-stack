using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPSCardStack.CardSystem
{
    public class ResourceCardView : CardView, IValuableView
    {
        [SerializeField] protected TextMeshPro _coinValueText;

        public void UpdateValuableDisplay(int value)
        {
            if (_coinValueText == null)
            {
                return;
            }
            _coinValueText.text = value.ToString();
        }
    }
}
