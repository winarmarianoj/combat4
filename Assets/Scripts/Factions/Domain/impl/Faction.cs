using UnityEngine;

namespace Factions.domain.impl
{
    public class Faction : MonoBehaviour, IFaction
    {
        [SerializeField] protected string factionId;
        [SerializeField] private string factionName;
        
        public string FactionId => factionId;
        public string FactionName => factionName;
        public string GetFactionId()
        {
            return FactionId;
        }
    }
}