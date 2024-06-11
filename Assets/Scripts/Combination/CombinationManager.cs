using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singleton;

using RPSCardStack.CardSystem;

namespace RPSCardStack.CombinationSystem
{
    public class CombinationManager : MonoBehaviorSingletonPersistent<CombinationManager>
    {
        public void CheckStack(CardController cardController)
        {
            CardController cardToCheck = cardController;
            string stackMessage = "Stack: ";
            while (cardToCheck != null)
            {
                stackMessage += $"{cardToCheck.CardName}|";
                cardToCheck = cardToCheck.StackedOnCard;
            }

            Debug.Log($"{stackMessage}");
        }

        public void CheckUnstack(CardController cardController)
        {

        }
    }
}
