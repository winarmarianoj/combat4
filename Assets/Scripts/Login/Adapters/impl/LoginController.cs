using System;
using System.Collections.Generic;
using Login.Service;
using Login.Service.impl;
using UniRx;
using Utils;

namespace Login.Adapters.impl
{
    public class LoginController : IDisposable, ILoginController
    {
        private readonly IPlayerDtoService _playerDtoService;
        private List<IDisposable> _disposables;

        public LoginController(ILoginViewModel loginViewModel, IPlayerDtoService playerDtoServiceImpl)
        {
            _playerDtoService = playerDtoServiceImpl;

            /*_loginViewModel.LoginNickName
                .Subscribe(OnLoginButtonPressed);*/

            loginViewModel.LoginNickNameButton.Subscribe(OnLoginButtonPressed).AddTo(_disposables);
        }

        private void OnLoginButtonPressed(string nickName)
        {
            _playerDtoService.Login(nickName);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}