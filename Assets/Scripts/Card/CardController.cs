using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

using ReadOnlyParameter;

using RPSCardStack.DraggableSystem;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(CardModel))]
    [RequireComponent(typeof(CardView))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SortingGroup))]

    public class CardController : MonoBehaviour, IDraggable
    {
        protected CardModel _cardModel;
        protected CardView _cardView;
        protected Collider2D _cardCollider;
        protected SortingGroup _cardSortingGroup;

        [SerializeField] protected Transform _stackPoint;
        public Transform StackPoint { get => _stackPoint; }

        [SerializeField] [ReadOnly] protected bool _canBeDragged;
        public bool CanBeDragged { get => _canBeDragged; set => _canBeDragged = value; }
        [SerializeField] [ReadOnly] protected bool _isDragged;
        public bool IsDragged { get => _isDragged; set => _isDragged = value; }
        [SerializeField] [ReadOnly] protected bool _isStacked;
        public bool IsStacked { get => _isStacked; set => _isStacked = value; }
        /*[SerializeField] [ReadOnly] protected bool _canBeStacked;
        public bool CanBeStacked { get => _canBeStacked; set => _canBeStacked = value; }*/
        [SerializeField] [ReadOnly] protected CardController _stackedOnCard;
        public CardController StackedOnCard { get => _stackedOnCard; private set => _stackedOnCard = value; }

        protected Vector3 _lastPos;

        [SerializeField] private string _cardDefaultSortName;
        [SerializeField] private string _cardDraggedSortName;

        public delegate void CardDragPositionEvent();
        public event CardDragPositionEvent CardPositionDragged;

        public delegate void CardDragSortEvent(bool isDragged, int sortingOrder);
        public event CardDragSortEvent CardSortingDragged;

        public int ZOrder
        {
            private set 
            {
                if (_cardSortingGroup != null)
                {
                    _cardSortingGroup.sortingOrder = value;
                } 
            }
            get 
            { 
                if (_cardSortingGroup != null)
                {
                    return _cardSortingGroup.sortingOrder;
                }

                return 0;
            }
        }

        protected void Awake()
        {
            _cardModel = GetComponent<CardModel>();
            _cardView = GetComponent<CardView>();
            _cardCollider = GetComponent<Collider2D>();
            _cardSortingGroup = GetComponent<SortingGroup>();
            CanBeDragged = true;
            IsStacked = false;
            /*CanBeStacked = true;*/
        }

        protected void Start()
        {
            _lastPos = transform.position;
            _cardView.UpdateCardName(_cardModel.CardName);
            HandleDragEnd();
        }

        public bool AllowedToStack(CardController cardToStack)
        {
            return (!IsStacked);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetDraggerPos(eventData);
            ToggleDragSorting(true, 0);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!CanBeDragged)
            {
                return;
            }

            _lastPos = transform.position;

            SetDraggerPos(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            HandleDragEnd();
        }

        protected void SetDraggerPos(PointerEventData eventData)
        {
            Vector3 dragPos = Camera.main.ScreenToWorldPoint(eventData.position);
            transform.position = new Vector3(dragPos.x, dragPos.y, transform.position.z);
            CardPositionDragged?.Invoke();
        }

        protected void ToggleDragSorting(bool isDragged, int sortingOrder = 0)
        {
            IsDragged = isDragged;
            _cardSortingGroup.sortingLayerName = (isDragged) ? _cardDraggedSortName: _cardDefaultSortName;
            ZOrder = sortingOrder;
            CardSortingDragged?.Invoke(isDragged, sortingOrder);
        }

        protected void HandleDragEnd()
        {
            Debug.Log($"{_cardModel.CardName} DRAG END");

            List<Collider2D> overlapColliders = new List<Collider2D>();
            Physics2D.OverlapCollider(_cardCollider, new ContactFilter2D().NoFilter(), overlapColliders);

            List<CardController> overlapCardController = new List<CardController>();
            foreach(Collider2D overlapCollider in overlapColliders)
            {
                if (overlapCollider.TryGetComponent(out CardController cardController))
                {
                    if (!cardController.IsDragged)
                    {
                        overlapCardController.Add(cardController);
                    }
                }
            }

            if (overlapCardController.Count <= 0)
            {
                ToggleDragSorting(false);
                StackWithCard(null);
            }
            else
            {
                foreach (CardController cardController in overlapCardController)
                {
                    if (cardController.AllowedToStack(this))
                    {
                        StackWithCard(cardController);
                        return;
                    }
                }

                transform.position = _lastPos;
                ToggleDragSorting(false);
            }
        }

        protected void StackWithCard(CardController cardToStackTo)
        {
            if (StackedOnCard != null)
            {
                if (cardToStackTo == StackedOnCard)
                {
                    return;
                }

                StackedOnCard.CardPositionDragged -= HandleCardStackPos;
                StackedOnCard.CardSortingDragged -= HandleCardStackSort;
                StackedOnCard.IsStacked = false;
                StackedOnCard = null;
            }
            
            if (cardToStackTo == null)
            {
                ToggleDragSorting(false);
            }
            else
            {
                StackedOnCard = cardToStackTo;
                StackedOnCard.IsStacked = true;
                StackedOnCard.CardPositionDragged += HandleCardStackPos;
                StackedOnCard.CardSortingDragged += HandleCardStackSort;
                transform.position = StackedOnCard.StackPoint.position;
                ToggleDragSorting(false, cardToStackTo.ZOrder + 1);
                Debug.Log($"{gameObject.name} Stack with {cardToStackTo.gameObject.name}");
            }
        }

        protected void HandleCardStackPos()
        {
            if (StackedOnCard == null)
            {
                return;
            }

            transform.position = new Vector3(StackedOnCard.StackPoint.position.x, StackedOnCard.StackPoint.position.y, transform.position.z);
            CardPositionDragged?.Invoke();
        }

        protected void HandleCardStackSort(bool isDragged, int sortingOrder)
        {
            if (StackedOnCard == null)
            {
                return;
            }

            ToggleDragSorting(isDragged, sortingOrder + 1);
            HandleCardStackPos();
        }
    }
}
