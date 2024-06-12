using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singleton;

using RPSCardStack.CardSystem;

namespace RPSCardStack.CombinationSystem
{
    public class CombinationManager : MonoBehaviorSingletonPersistent<CombinationManager>
    {
        [SerializeField] private List<CardFormulaData> _generalCombinationDatas = new List<CardFormulaData>();
        
        public void CheckStack(CardController cardController)
        {
            List<CardController> cardStack = new List<CardController>();
            CardController cardToCheck = cardController;
            string stackMessage = "Stack: ";
            while (cardToCheck != null)
            {
                stackMessage += $"{cardToCheck.CardData.CardName}|";
                cardStack.Add(cardToCheck);
                cardToCheck = cardToCheck.StackedOnCard;
            }
            
            if (cardStack == null)
            {
                return;
            }

            Debug.Log($"Check Stack of {stackMessage}");

            // Find Generator that can be used in the stack
            for(int cardInd = 0; cardInd < cardStack.Count; cardInd++)
            {
                if (cardStack[cardInd].TryGetComponent(out IGeneratorController generatorController))
                {
                    Debug.Log($"{cardStack[cardInd]} IS A GENERATOR");
                    CheckUseableFormula
                        (cardStack,
                        cardInd,
                        generatorController,
                        out CardFormulaData usedCardFormulaData,
                        out List<int> usedIndexs
                    );

                    if (usedCardFormulaData != null)
                    {
                        Debug.Log($"{cardStack[cardInd].CardData.CardName} can generate {usedCardFormulaData.ResultCard.CardName}");
                        return;
                    }
                }
            }

            Debug.Log($"No Generator useable in Stack");

            // If no Generator, use General Combo Databae
            for (int cardInd = 0; cardInd < cardStack.Count; cardInd++)
            {
                foreach(CardFormulaData formulaData in _generalCombinationDatas)
                {
                    if (cardStack.Count - cardInd >= formulaData.RequiredCards.Count)
                    {
                        List<int> tempIndexs = FindCombinationIgnoreOrder(formulaData.RequiredCards, cardStack.GetRange(cardInd, cardStack.Count - cardInd));
                        if (tempIndexs.Count > 0)
                        {
                            Debug.Log($"{formulaData.ResultCard.CardName} from {formulaData.name} Can be Create");
                            return;
                        }
                    }
                }
            }

            Debug.Log($"No Combination Detected");
        }

        public void CheckUnstack(CardController cardController)
        {

        }

        private void CheckUseableFormula
            (
                List<CardController> stack,
                int generatorIndex,
                IGeneratorController generatorController,
                out CardFormulaData cardFormulaDataUsed,
                out List<int> indexUsed

            )
        {
            cardFormulaDataUsed = null;
            indexUsed = new List<int>();

            if (generatorController.CombinationFormulas.Count <= 0)
            {
                return;
            }
            
            List<CardController> cardsToCheck = new List<CardController>();
            switch(generatorController.ReqType)
            {
                case StackReqType.StackAbove:
                    for(int ind = 0; ind < generatorIndex; ind++)
                    {
                        cardsToCheck.Add(stack[ind]);
                    }
                    break;
                case StackReqType.StackBelow:
                    for (int ind = generatorIndex + 1; ind < stack.Count; ind++)
                    {
                        cardsToCheck.Add(stack[ind]);
                    }
                    break;
            }

            if (cardsToCheck.Count <= 0)
            {
                return;
            }

            foreach (CardFormulaData cardFormulaData in generatorController.CombinationFormulas)
            {
                List<int> tempIndexs = new List<int>();
                if (cardFormulaData.IsOrderExact)
                {
                    tempIndexs = FindCombinationExactOrder(cardFormulaData.RequiredCards, cardsToCheck);
                }
                else
                {
                    tempIndexs = FindCombinationIgnoreOrder(cardFormulaData.RequiredCards, cardsToCheck);
                }

                if (tempIndexs.Count > 0)
                {
                    cardFormulaDataUsed = cardFormulaData;
                    indexUsed = tempIndexs;
                    return;
                }
            }
        }

        private List<int> FindCombinationExactOrder(List<CardData> cardReqs, List<CardController> checkedCardStack)
        {
            int reqLength = cardReqs.Count;
            int stackLength = checkedCardStack.Count;
            List<int> comboCardInd = new List<int>();

            for (int i = 0; i <= stackLength - reqLength; i++)
            {
                bool match = true;
                for (int j = 0; j < reqLength; j++)
                {
                    if (checkedCardStack[i + j].CardData != cardReqs[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    for (int j = 0; j < reqLength; j++)
                    {
                        comboCardInd.Add(i + j);
                    }
                    return comboCardInd;  // Return indices of the first found subsequence
                }
            }

            return comboCardInd;
        }
        
        private List<int> FindCombinationIgnoreOrder(List<CardData> cardReqs, List<CardController> checkedCardStack)
        {
            List<int> comboCardInd = new List<int>();

            string stackMemberName = "";
            foreach(CardController cardController in checkedCardStack)
            {
                stackMemberName += $"{cardController.CardData.CardName}|";
            }

            Debug.Log($"FindCombinationIgnoreOrder in {stackMemberName}");

            Dictionary<CardData, int> countReq = cardReqs.GroupBy(x => x).ToDictionary(y => y.Key, y => y.Count());
            Dictionary<CardData, int> countStack = checkedCardStack.GroupBy(x => x.CardData).ToDictionary(y => y.Key, y => y.Count());
            
            foreach(var countReqData in countReq)
            {
                if (!countStack.ContainsKey(countReqData.Key) || countStack[countReqData.Key] < countReqData.Value)
                {
                    return comboCardInd;
                }
            }

            Dictionary<CardData, int> remainingCount = new Dictionary<CardData, int>(countReq);

            for (int ind = 0; ind < checkedCardStack.Count; ind++)
            {
                CardData cardData = checkedCardStack[ind].CardData;
                if (remainingCount.ContainsKey(cardData) && remainingCount[cardData] > 0)
                {
                    comboCardInd.Add(ind);
                    remainingCount[cardData]--;
                    if (remainingCount.Values.All(v => v == 0))
                    {
                        return comboCardInd;
                    }
                }
            }

            return comboCardInd;
        }
    }
}
