using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPSCardStack.DraggableSystem
{
    public interface IDraggable : IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool CanBeDragged { set; get; }
    }
}
