using System;
using System.Collections.Generic;
using Exception;
using Factions.domain.impl;
using UnityEngine;

namespace Factions.factory.impl
{
    [CreateAssetMenu(menuName = "Custom/Faction configuration")]
    public class FactionConfiguration : ScriptableObject
    {
        [SerializeField] private Faction[] _factions;
        private Dictionary<string, Faction> factionDictionary;
        private Errors _errors;

        public FactionConfiguration(Errors errors)
        {
            _errors = errors;
        }

        private void Awake()
        {
            factionDictionary = new Dictionary<string, Faction>();
            foreach (var faction in _factions)
            {
                factionDictionary.Add(faction.GetFactionId(), faction);
            }
        }

        public Faction GetFactionById(string id)
        {
            if (!factionDictionary.TryGetValue(id, out var faction))
            {
                //throw new Exception($"Faction with id {id} does not exist");
                _errors.LogErrors($"Faction with id {id} does not exist");
            }

            return faction;
        }
    }
}