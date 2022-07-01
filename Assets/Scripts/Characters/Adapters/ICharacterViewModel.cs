using Characters.domain.impl;
using UniRx;

namespace Characters.Adapters
{
    public interface ICharacterViewModel
    {
        ReactiveProperty<Local> CharacterLocal { get; set; }
        ReactiveProperty<Visitor1> CharacterVisitor { get; set; }
    }
}