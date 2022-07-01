using System.Collections.Generic;
using Characters.domain.impl;
using Factions.domain;
using UnityEngine;

namespace Characters.factory.impl
{
    public class Factory : IFactory
    {
        private const int START_LEVEL = 1;
        private const int START_HP = 1000;
        private const int POSITION = 0;
        
        public Character CreateNewCharacter()
        {
            GameObject gameObject = new GameObject();
            var character = gameObject.AddComponent<Character>();
            character.Score = POSITION;
            character.Hp = START_HP;
            character.Level = START_LEVEL;
            character.Alive = true;
            character.Position = POSITION;

            if (character.Factions == null) character.Factions = new List<IFaction>();
            return character;
        }
    }
}