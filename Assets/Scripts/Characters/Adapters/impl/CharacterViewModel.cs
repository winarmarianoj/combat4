using Characters.domain.impl;
using UniRx;

namespace Characters.Adapters.impl
{
    public class CharacterViewModel : ICharacterViewModel
    {
        public ReactiveProperty<Local> CharacterLocal { get; set; }
        public ReactiveProperty<Visitor1> CharacterVisitor { get; set; }

        public CharacterViewModel(ReactiveProperty<Local> characterLocal, ReactiveProperty<Visitor1> characterVisitor)
        {
            CharacterLocal = characterLocal;
            CharacterVisitor = characterVisitor;
        }
        
        
    }
}