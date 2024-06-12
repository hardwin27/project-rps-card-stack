using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{ 
    [RequireComponent(typeof(AgentCardController))]
    public class AgentCardDataAssigner : MonoBehaviour
    {
        [SerializeField] private AgentCardData _agentCardData;
        private AgentCardController _agentCardController;

        private void Awake()
        {
            _agentCardController = GetComponent<AgentCardController>();
        }

        private void Start()
        {
            if (_agentCardData != null)
            {
                _agentCardController.SetAgentCardData(_agentCardData);
            }
        }
    }
}
