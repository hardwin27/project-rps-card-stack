using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface ICardView
    {
        public void UpdateBaseDisplay(string name, Sprite sprite);   
    }
}
