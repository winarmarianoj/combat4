using UnityEngine;

namespace Rivals.factory.impl
{
    public class RivalFactory : IRivalFactory
    {
        private readonly RivalConfiguration _rivalConfiguration;

        public RivalFactory(RivalConfiguration rivalConfiguration)
        {
            _rivalConfiguration = rivalConfiguration;
        }

        public domain.impl.Rival Create(string rivalId)
        {
            var faction = _rivalConfiguration.GetRivalById(rivalId);
            return Object.Instantiate(faction);
        }
    }
}