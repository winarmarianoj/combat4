namespace Weapons.factory
{
    public interface IWeaponFactory
    {
        domain.impl.Weapon Create(string weaponId);
    }
}