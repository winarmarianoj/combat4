using Characters.domain.impl;
using Login.DTO;

namespace Characters.factory
{
    public interface ICharacterFactory
    {
        Character Create(string characterId);
        Local CreateCharacterLocal(IPlayerDto playerDto);
        Visitor1 CreateCharacterLoVisitor1();

    }
}