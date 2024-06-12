using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(GeneratorCardModel), typeof(GeneratorCardView))]
    public class GeneratorCardController : CardController, IGeneratorController, IValuableController
    {
        private GeneratorCardModel _generatorCardModel;
        private GeneratorCardView _generatorCardView;

        public List<CardFormulaData> CombinationFormulas
        {
            get
            {
                if (_generatorCardModel != null)
                {
                    return _generatorCardModel.CombinationFormulas;
                }
                return new List<CardFormulaData>();
            }
        }

        public int CoinValue
        {
            get
            {
                if (_generatorCardModel != null)
                {
                    return _generatorCardModel.CoinValue;
                }
                return 0;
            }

        }

        public StackReqType ReqType
        {
            get
            {
                if (_generatorCardModel != null)
                {
                    return _generatorCardModel.ReqType;
                }
                return StackReqType.StackAbove;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _generatorCardModel = GetComponent<GeneratorCardModel>();
            _generatorCardView = GetComponent<GeneratorCardView>();
        }

        public void SetGeneratorCardData(GeneratorCardData generatorCardData)
        {
            SetCardData(generatorCardData);
            SetGeneratorData(generatorCardData);
            SetValuableData(generatorCardData);
        }

        public void SetGeneratorData(IGeneratorData generatorData)
        {
            _generatorCardModel.InitiateGeneratorData(generatorData);
            _generatorCardView.UpdateGeneratorDisplay();
        }

        public void SetValuableData(IValuableData valuableData)
        {
            _generatorCardModel.InitiateValuableData(valuableData);
            _generatorCardView.UpdateValuableDisplay(valuableData.CoinValue);
        }
    }
}
