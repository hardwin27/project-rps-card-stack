using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.CardSystem;

namespace HaruEru.Debugger
{
    public class CardInterfaceDebug : MonoBehaviour
    {
        [SerializeField] private List<CardController> _cardControllers = new List<CardController>();

        private void Start()
        {
            foreach(CardController cardController in _cardControllers)
            {
                if (cardController is ICardController)
                {
                    Debug.Log($"{cardController.name} is CardController");
                }

                if (cardController is IValuableController)
                {
                    Debug.Log($"{cardController.name} is ValuableController");
                }

                if (cardController is IGeneratorController)
                {
                    Debug.Log($"{cardController.name} is GeneratorController");
                }
            }
        }
    }
}
