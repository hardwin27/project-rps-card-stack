using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RPSCardStack.CardSystem
{
    public class GeneratorCardView : CardView, IGeneratorView, IValuableView
    {
        [SerializeField] protected TextMeshPro _coinValueText;

        public void UpdateGeneratorDisplay()
        {
            return;
        }

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
