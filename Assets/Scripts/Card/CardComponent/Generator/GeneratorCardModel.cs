using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ReadOnlyParameter;

namespace RPSCardStack.CardSystem
{
    public class GeneratorCardModel : CardModel, IGeneratorModel, IValuableModel
    {
        [SerializeField] [ReadOnly] private StackReqType _reqType;
        [SerializeField] [ReadOnly] private List<CardFormulaData> _combinationFormula = new List<CardFormulaData>();
        [SerializeField] [ReadOnly] private int _coinValue;

        public StackReqType ReqType { get => _reqType; }
        public List<CardFormulaData> CombinationFormulas { get => _combinationFormula; }

        public int CoinValue { get => _coinValue; }

        public void InitiateGeneratorData(IGeneratorData generatorData)
        {
            _reqType = generatorData.ReqType;
            _combinationFormula = generatorData.CombinationFormulas;
        }

        public void InitiateValuableData(IValuableData valuableData)
        {
            _coinValue = valuableData.CoinValue;
        }
    }
}
