using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.CombinationSystem;

namespace RPSCardStack.CardSystem
{
    public interface IGeneratorModel
    {
        public StackReqType ReqType { get; }
        public List<CardFormulaData> CombinationFormulas { get; }

        public void InitiateGeneratorData(IGeneratorData generatorData);
    }
}
