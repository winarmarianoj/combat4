using System;
using System.Collections.Generic;
using Exception;
using UnityEngine;
using Weapons.domain.impl;

namespace Weapons.factory.impl
{
    [CreateAssetMenu(menuName = "Custom/Weapon configuration")]
    public class WeaponConfiguration : ScriptableObject
    {
        [SerializeField] private Weapon[] _weapons;
        private Dictionary<string, Weapon> weaponDictionary;
        private Errors _errors;

        public WeaponConfiguration(Errors errors)
        {
            _errors = errors;
        }

        private void Awake()
        {
            weaponDictionary = new Dictionary<string, Weapon>();
            foreach (var weapon in _weapons)
            {
                weaponDictionary.Add(weapon.GetWeaponId(), weapon);
            }
        }

        public Weapon GetWeaponById(string id)
        {
            if (!weaponDictionary.TryGetValue(id, out var weapon))
            {
                //throw new Exception($"Weapon with id {id} does not exist");
                _errors.LogErrors($"Weapon with id {id} does not exist");
            }

            return weapon;
        }
    }
}