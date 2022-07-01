namespace Factions.factory
{
    public interface IFactionFactory
    {
        domain.impl.Faction Create(string weaponId);
    }
}