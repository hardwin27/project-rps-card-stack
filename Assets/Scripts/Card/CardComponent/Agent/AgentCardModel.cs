using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class AgentCardModel : CardModel, IGeneratorModel
    {
        [SerializeField] [ReadOnly] private StackReqType _reqType;
        [SerializeField] [ReadOnly] private List<CardFormulaData> _cardFormulaDatas;

        public StackReqType ReqType { get => _reqType; }
        public List<CardFormulaData> CombinationFormulas { get => _cardFormulaDatas; }

        public void InitiateGeneratorData(IGeneratorData generatorData)
        {
            _reqType = generatorData.ReqType;
            _cardFormulaDatas = generatorData.CombinationFormulas;
        }
    }
}
