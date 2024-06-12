using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPSCardStack.CardSystem
{
    [RequireComponent(typeof(GeneratorCardController))]
    public class GeneratorCardDataAssigner : MonoBehaviour
    {
        [SerializeField] private GeneratorCardData _generatorCardData;

        private GeneratorCardController _generatorCardController;

        private void Awake()
        {
            _generatorCardController = GetComponent<GeneratorCardController>();
        }

        private void Start()
        {
            if (_generatorCardData != null)
            {
                _generatorCardController.SetGeneratorCardData(_generatorCardData);
            }
        }
    }
}
