using System.Collections.Generic;
using System.Linq;
using Factions.domain;
using UnityEngine;

namespace Characters.domain.impl
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string characterId;
        [SerializeField] private new string name;
        [SerializeField] private int score;
        [SerializeField] private int hp;
        [SerializeField] private int level;
        [SerializeField] private bool alive;
        [SerializeField] private int position;
        [SerializeField] private List<IFaction> _factions;

        private const int START_LEVEL = 1;
        private const int START_HP = 1000;
        private const int ZERO = 0;
        private const int MINOR_POSITION = 2;
        private const int MAJOR_POSITION = 20;

        public string CharacterID => characterId;
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Score
        {
            get => score;
            set => score = value;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public bool Alive
        {
            get => alive;
            set => alive = value;
        }

        public int Position
        {
            get => position;
            set => position = value;
        }

        public List<IFaction> Factions
        {
            get => _factions;
            set => _factions = value;
        }

        public void DealDamage(Character target, int amountDamage)
        {
            if (target == this || target.IsAlly(this) || !PositionWar(target)) return;
            target.ReceiveDamage(this, amountDamage);
        }

        private void ReceiveDamage(Character character, int amountDamage)
        {
            Hp = character.Level - Level == 0 ? character.hp - amountDamage : Hp;
            Hp = character.Level - Level >= 5 ? character.hp - (amountDamage / 2) : Hp;
            Hp = (int) (Level - character.Level >= 5 ? character.hp - (amountDamage * 1.5) : Hp);
            Alive = Hp > ZERO;
        }

        public void DealHeal(Character target, int amountHeal)
        {
            if(!Alive || target!=this || !target.IsAlly(this)) return;
            Hp = target.hp + amountHeal > START_HP ? START_HP : target.hp + amountHeal;
        }

        public bool PositionWar(Character target)
        {
            return Position - target.Position >= MINOR_POSITION && Position - target.Position <= MAJOR_POSITION;
        }

        public bool FactionContainsList(IFaction faction)
        {
            return Factions.Contains(faction);
        }
        
        public bool FactionNotContainsList(IFaction blade)
        {
            return !Factions.Contains(blade);
        }
      
        
        public bool IsAlly(Character target)
        {
            return _factions.Any(target.IsInFaction);
        }

        private bool IsInFaction(IFaction faction)
        {
            return _factions.Any(it => it.GetType() == faction.GetType());
        }

        public void AddFactions(IFaction blade)
        {
            if (!Factions.Contains(blade)) _factions.Add(blade);
        }

        public void DeleteFactions(IFaction blade)
        {
            if (Factions.Contains(blade)) _factions.Remove(blade);
        }

       
    }
}