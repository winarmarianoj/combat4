using Characters.factory.impl;
using UnityEngine;
using Consumers;
using Factions.factory.impl;
using Factories.impl;
using Rivals.factory.impl;
using Weapons.factory.impl;

namespace Installer
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private CharacterConfiguration characterConfiguration;
        [SerializeField] private FactionConfiguration factionConfiguration;
        [SerializeField] private RivalConfiguration rivalConfiguration;
        [SerializeField] private WeaponConfiguration weaponConfiguration;

        private void Start()
        {
            var characterFactory = new CharacterFactory(Instantiate(characterConfiguration));
            var factionFactory = new FactionFactory(Instantiate(factionConfiguration));
            var rivalFactory = new RivalFactory(Instantiate(rivalConfiguration));
            var weaponFactory = new WeaponFactory(Instantiate(weaponConfiguration));

            var consumerGameObject = new GameObject();
            var consumer = consumerGameObject.AddComponent<Consumer>();
            consumer.Configure(new BeattleFactory(characterFactory, factionFactory, rivalFactory, weaponFactory));
        }
    }
}