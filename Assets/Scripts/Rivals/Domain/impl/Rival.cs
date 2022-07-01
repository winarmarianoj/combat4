using UnityEngine;

namespace Rivals.domain.impl
{
    public class Rival : MonoBehaviour, IRival
    {
        [SerializeField] protected string rivalId;
        [SerializeField] private string rivalName;
        
        public string RivalId => rivalId;
        public string RivalName => rivalName;

        public string GetRivalId()
        {
            return RivalId;
        }
    }
}