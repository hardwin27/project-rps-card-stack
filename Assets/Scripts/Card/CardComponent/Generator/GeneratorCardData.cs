using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [CreateAssetMenu(fileName = "GeneratorData", menuName = "Card Data/Generator Data")]
    public class GeneratorCardData : CardData, IGeneratorData, IValuableData
    {
        [SerializeField] private StackReqType _reqType;
        [SerializeField] private List<CardFormulaData> _combinationFormula = new List<CardFormulaData>();
        [SerializeField] private int _coinValue;

        public StackReqType ReqType { get => _reqType; }
        public List<CardFormulaData> CombinationFormulas { get => _combinationFormula; }

        public int CoinValue { get => _coinValue; }
    }
}
