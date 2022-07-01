using System;
using System.Collections.Generic;
using Exception;
using Rivals.domain.impl;
using UnityEngine;

namespace Rivals.factory.impl
{
    [CreateAssetMenu(menuName = "Custom/Rival configuration")]
    public class RivalConfiguration : ScriptableObject
    {
        [SerializeField] private Rival[] _rivals;
        private Dictionary<string, Rival> rivalDictionary;
        private Errors _errors;

        public RivalConfiguration(Errors errors)
        {
            _errors = errors;
        }

        private void Awake()
        {
            rivalDictionary = new Dictionary<string, Rival>();
            foreach (var rival in _rivals)
            {
                rivalDictionary.Add(rival.GetRivalId(), rival);
            }
        }

        public Rival GetRivalById(string id)
        {
            if (!rivalDictionary.TryGetValue(id, out var rival))
            {
                //throw new Exception($"Rival with id {id} does not exist");
                _errors.LogErrors($"Rival with id {id} does not exist");
            }

            return rival;
        }
    }
}