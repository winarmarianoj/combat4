using Characters.domain.impl;

namespace Characters.Configurations
{
    public interface ICharacterConfigurationFight
    {
        Character GetCharacterById(string id);
    }
}