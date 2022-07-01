using UnityEngine;

namespace Weapons.domain.impl
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] protected string weaponId;
        [SerializeField] private string weaponName;
        
        public string WeaponId => weaponId;
        public string WeaponName => weaponName;

        public string GetWeaponId()
        {
            return WeaponId;
        }
    }
}