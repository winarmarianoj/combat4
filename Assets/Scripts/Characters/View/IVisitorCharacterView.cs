using Characters.Adapters;

namespace Characters.View
{
    public interface IVisitorCharacterView
    {
        void Configure(ICharacterViewModel model);
    }
}