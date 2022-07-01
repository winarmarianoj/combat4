using Characters.Adapters;
using Characters.domain.impl;
using Factions.domain.impl;
using TMPro;
using UniRx;
using UnityEngine;

namespace Characters.View.impl
{
    public class VisitorCharacterView : MonoBehaviour, IVisitorCharacterView
    {
        [SerializeField] private TextMeshProUGUI visitorName;
        [SerializeField] private TextMeshProUGUI visitorScore;
        [SerializeField] private Faction[] factions;
        
        private ICharacterViewModel _characterViewModel;

        public void Configure(ICharacterViewModel model)
        {
            _characterViewModel = model;
            _characterViewModel.CharacterVisitor.Subscribe(UpdatedVisitor);
        }
        
        private void UpdatedVisitor(Visitor1 visitor1)
        {
            visitorName.SetText(visitor1.Name);
            visitorScore.SetText(visitor1.Score.ToString());

        }
        
    }
}