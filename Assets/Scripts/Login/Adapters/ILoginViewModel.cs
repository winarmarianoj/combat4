using UniRx;

namespace Login.Adapters
{
    public interface ILoginViewModel
    {
        ReactiveProperty<string> LoginNickName { get; set; }
        ReactiveCommand<string> LoginNickNameButton { get; set; }
        void Login(string nickNameText);
    }
}