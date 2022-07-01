using System.Collections.Generic;
using Characters.domain.impl;
using Factions.domain;
using Login.DTO;
using UnityEngine;

namespace Characters.factory.impl
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly CharacterConfiguration _characterConfiguration;
        private const int START_LEVEL = 1;
        private const int START_HP = 1000;
        private const int POSITION = 0;

        public CharacterFactory(CharacterConfiguration characterConfiguration)
        {
            _characterConfiguration = characterConfiguration;
        }

        public Character Create(string characterId)
        {
            var character = _characterConfiguration.GetCharacterById(characterId);
            return Object.Instantiate(character);
        }

        public Local CreateCharacterLocal(IPlayerDto playerDto)
        {
            GameObject gameObject = new GameObject();
            var local = gameObject.AddComponent<Local>();
            local.Name = playerDto.GetNamePlayerDto();
            local.Score = POSITION;
            local.Hp = START_HP;
            local.Level = START_LEVEL;
            local.Alive = true;
            local.Position = POSITION;

            if (local.Factions == null) local.Factions = new List<IFaction>();
            return local;
        }
        
        public Visitor1 CreateCharacterLoVisitor1()
        {
            GameObject gameObject = new GameObject();
            var local = gameObject.AddComponent<Visitor1>();
            local.Name = "Visitor Fight";
            local.Score = POSITION;
            local.Hp = START_HP;
            local.Level = START_LEVEL;
            local.Alive = true;
            local.Position = POSITION;

            if (local.Factions == null) local.Factions = new List<IFaction>();
            return local;
        }

    }
}