using Weapons.domain.impl;
using UnityEngine;

namespace Weapons.factory.impl
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly WeaponConfiguration _weaponConfiguration;

        public WeaponFactory(WeaponConfiguration weaponConfiguration)
        {
            _weaponConfiguration = weaponConfiguration;
        }

        public Weapon Create(string weaponId)
        {
            var weapon = _weaponConfiguration.GetWeaponById(weaponId);
            return Object.Instantiate(weapon);
        }
    }
}