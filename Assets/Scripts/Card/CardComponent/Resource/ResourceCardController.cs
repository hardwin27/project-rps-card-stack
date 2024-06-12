using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(ResourceCardModel), typeof(ResourceCardView))]
    public class ResourceCardController : CardController, IValuableController
    {
        private ResourceCardModel _resourceCardModel;
        private ResourceCardView _resourceCardView;

        public int CoinValue
        {
            get
            {
                if (_resourceCardModel != null)
                {
                    return _resourceCardModel.CoinValue;
                }
                return 0;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _resourceCardModel = GetComponent<ResourceCardModel>();
            _resourceCardView = GetComponent<ResourceCardView>();
        }

        protected override void Start()
        {
            base.Start();
        }

        public void SetResourcCardeData(ResourceCardData resourceCardData)
        {
            SetCardData(resourceCardData);
            SetValuableData(resourceCardData);
        }

        public void SetValuableData(IValuableData valuableData)
        {
            _resourceCardModel.InitiateValuableData(valuableData);
            _resourceCardView.UpdateValuableDisplay(_resourceCardModel.CoinValue);
        }
    }
}
