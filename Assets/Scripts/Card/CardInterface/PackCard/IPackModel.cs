using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    public interface IPackModel
    {
        List<CardSetProbability> CardSetProbabilities { get; }
        public int CurrentCapacity { get; }

        public void InitiatePackData(IPackData packData);
    }
}
