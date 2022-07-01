using Characters.domain.impl;
using Characters.factory;
using Characters.factory.impl;
using Factions.domain.impl;
using Factions.factory;
using Factions.factory.impl;
using Rivals.domain.impl;
using Rivals.factory;
using Rivals.factory.impl;
using Weapons.domain.impl;
using Weapons.factory;
using Weapons.factory.impl;

namespace Factories.impl
{
    public class BeattleFactory : IBeattleFactory
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly IFactionFactory _factionFactory;
        private readonly IRivalFactory _rivalFactory;
        private readonly IWeaponFactory _weaponFactory;

        public BeattleFactory(CharacterFactory characterFactory, FactionFactory factionFactory, RivalFactory rivalFactory, WeaponFactory weaponFactory)
        {
            _characterFactory = characterFactory;
            _factionFactory = factionFactory;
            _rivalFactory = rivalFactory;
            _weaponFactory = weaponFactory;
        }

        public Character CreateCharacter(string characterId)
        {
            return _characterFactory.Create(characterId);
        }

        public Faction CreateFaction(string factionId)
        {
            return _factionFactory.Create(factionId);
        }

        public Rival CreateRival(string rivalId)
        {
            return _rivalFactory.Create(rivalId);
        }

        public Weapon CreateWeapon(string weaponId)
        {
            return _weaponFactory.Create(weaponId);
        }
    }
}