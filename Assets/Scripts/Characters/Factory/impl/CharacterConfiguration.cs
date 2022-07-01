using System;
using System.Collections.Generic;
using Characters.domain.impl;
using Exception;
using UnityEngine;

namespace Characters.factory.impl
{
    [CreateAssetMenu(menuName = "Custom/Character configuration")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private Character[] _characters;
        private Dictionary<string, Character> characterDictionary;
        private Errors _errors;

        public CharacterConfiguration(Errors errors)
        {
            _errors = errors;
        }

        private void Awake()
        {
            characterDictionary = new Dictionary<string, Character>();
            foreach (var character in _characters)
            {
                characterDictionary.Add(character.CharacterID, character);
            }
        }

        public Character GetCharacterById(string id)
        {
            if (!characterDictionary.TryGetValue(id, out var character))
            {
                //throw new Exception($"Character with id {id} does not exist");
                _errors.LogErrors($"Character with id {id} does not exist");
            }

            return character;
        }
    }
}