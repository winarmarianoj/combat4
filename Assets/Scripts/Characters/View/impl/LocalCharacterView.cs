using Characters.Adapters;
using Characters.domain.impl;
using Factions.domain.impl;
using TMPro;
using UniRx;
using UnityEngine;

namespace Characters.View.impl
{
    public class LocalCharacterView : MonoBehaviour, ILocalCharacterView
    {
        [SerializeField] private TextMeshProUGUI localName;
        [SerializeField] private TextMeshProUGUI localScore;
        [SerializeField] private Faction[] factions;

        private ICharacterViewModel _characterViewModel;
    
        public void Configure(ICharacterViewModel iCharacterViewModel)
        {
            _characterViewModel = iCharacterViewModel;
            _characterViewModel.CharacterLocal.Subscribe(UpdatedLocal);
        }

        private void UpdatedLocal(Local local)
        {
            localName.SetText(local.Name);
            localScore.SetText(local.Score.ToString());
            

        }
    
    }
}
