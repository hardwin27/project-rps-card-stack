using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(AgentCardModel), typeof(AgentCardView))]
    public class AgentCardController : CardController, IGeneratorController
    {
        private AgentCardModel _agentCardModel;
        private AgentCardView _agentCardView;

        public StackReqType ReqType
        {
            get
            {
                if (_agentCardModel != null)
                {
                    return _agentCardModel.ReqType;
                }
                return StackReqType.StackAbove;
            }
        }

        public List<CardFormulaData> CombinationFormulas
        {
            get
            {
                if (_agentCardModel != null)
                {
                    return _agentCardModel.CombinationFormulas;
                }
                return new List<CardFormulaData>();
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _agentCardModel = GetComponent<AgentCardModel>();
            _agentCardView = GetComponent<AgentCardView>();
        }

        public void SetAgentCardData(AgentCardData agentCardData)
        {
            SetCardData(agentCardData);
            SetGeneratorData(agentCardData);
        }

        public void SetGeneratorData(IGeneratorData generatorData)
        {
            _agentCardModel.InitiateGeneratorData(generatorData);
            _agentCardView.UpdateGeneratorDisplay();
        }
    }
}
