using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPSCardStack.CombinationSystem;

namespace RPSCardStack.CardSystem
{
    public enum StackReqType
    {
        StackAbove,
        StackBelow
    }

    public interface IGeneratorData
    {
        public StackReqType ReqType { get; }
        public List<CardFormulaData> CombinationFormulas { get; }
    }
}
