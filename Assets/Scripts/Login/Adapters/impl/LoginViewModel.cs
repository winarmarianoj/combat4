using UniRx;

namespace Login.Adapters.impl
{
    public class LoginViewModel : ILoginViewModel
    {
        public ReactiveProperty<string> LoginNickName { get; set; }
        public ReactiveCommand<string> LoginNickNameButton
        {
            get => _loginViewModelImplementation.LoginNickNameButton;
            set => _loginViewModelImplementation.LoginNickNameButton = value;
        }

        //public ReactiveProperty<string> UserName { get; set; }
        private string _nickname;
        private readonly ILoginViewModel _loginViewModelImplementation;

        public string Nickname => _nickname;


        public LoginViewModel(ILoginViewModel loginViewModelImplementation)
        {
            _loginViewModelImplementation = loginViewModelImplementation;
            LoginNickName = new StringReactiveProperty(Nickname);
            //LoginNickNameButton = new ReactiveCommand<string>();
            //UserName = new StringReactiveProperty("WARRIOR");
        }

        public LoginViewModel()
        {
            
        }

        public void Login(string nickNameText)
        {
            _nickname = nickNameText;
        }

    }
}