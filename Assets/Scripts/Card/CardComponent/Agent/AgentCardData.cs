using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [CreateAssetMenu(fileName = "AgentData", menuName = "Card Data/Agent")]
    public class AgentCardData : CardData, IGeneratorData
    {
        [SerializeField] private StackReqType _reqType;
        [SerializeField] private List<CardFormulaData> _combinationFormulas = new List<CardFormulaData>();
        
        public StackReqType ReqType { get => _reqType; }
        public List<CardFormulaData> CombinationFormulas { get => _combinationFormulas; }
    }
}
