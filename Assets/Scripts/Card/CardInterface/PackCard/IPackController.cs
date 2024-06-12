using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPSCardStack.CardSystem
{
    public interface IPackController : IPointerClickHandler
    {
        public void SetPackData(IPackData packData);
        public void GenerateCard();
    }
}
