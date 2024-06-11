using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(ResourceCardController))]
    public class ResourceCardDataAssigner : MonoBehaviour
    {
        [SerializeField] private ResourceCardData _resourceCardData;

        private ResourceCardController _resourceCardController;

        private void Awake()
        {
            _resourceCardController = GetComponent<ResourceCardController>();
        }

        private void Start()
        {
            if (_resourceCardData != null)
            {
                _resourceCardController.SetResourcCardeData(_resourceCardData);
            }
        }
    }
}
