using Characters.domain.impl;
using Factions.domain.impl;
using Login.DTO;
using Rivals.domain.impl;
using Weapons.domain.impl;

namespace Factories
{
    public interface IBeattleFactory
    {
        Character CreateCharacter(string characterId);
        Faction CreateFaction(string factionId);

        Rival CreateRival(string rivalId);

        Weapon CreateWeapon(string weaponId);
    }
}