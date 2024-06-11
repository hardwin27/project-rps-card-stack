using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(IValuableModel), typeof(IValuableView))]
    public class ResourceCardController : CardController, IValuableController
    {
        [SerializeField] private ResourceCardData _initialResourceCardData;

        protected IValuableModel _valuableModel;
        protected IValuableView _valuableView;

        public int CoinValue
        {
            get
            {
                if (_valuableModel != null)
                {
                    return _valuableModel.CoinValue;
                }
                return 0;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _valuableModel = GetComponent<IValuableModel>();
            _valuableView = GetComponent<IValuableView>();
        }

        protected override void Start()
        {
            base.Start();

            if (_initialResourceCardData != null)
            {
                SetResourcCardeData(_initialResourceCardData);
            }
        }

        public void SetResourcCardeData(ResourceCardData resourceCardData)
        {
            SetCardData(resourceCardData);
            SetValuableData(resourceCardData);
        }

        public void SetValuableData(IValuableData valuableData)
        {
            _valuableModel.InitiateValuableData(valuableData);
            _valuableView.UpdateValuableDisplay(_valuableModel.CoinValue);
        }
    }
}
