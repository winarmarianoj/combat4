using UnityEngine;

namespace Factions.factory.impl
{
    public class FactionFactory : IFactionFactory
    {
        private readonly FactionConfiguration _factionConfiguration;

        public FactionFactory(FactionConfiguration factionConfiguration)
        {
            _factionConfiguration = factionConfiguration;
        }

        public domain.impl.Faction Create(string factionId)
        {
            var faction = _factionConfiguration.GetFactionById(factionId);
            return Object.Instantiate(faction);
        }
    }
}