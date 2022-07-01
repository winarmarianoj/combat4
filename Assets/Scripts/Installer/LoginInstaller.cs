using System;
using System.Collections.Generic;
using System.Net.Http;
using Exception;
using Login.Adapters;
using Login.Adapters.impl;
using Login.DAO;
using Login.DAO.impl;
using Login.Factory.impl;
using Login.Service;
using Login.Service.impl;
using Login.View.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Installer
{
    public class LoginInstaller : MonoBehaviour, ILoginController
    {
        [SerializeField] private GameObject loginView;

        private ILoginViewModel _loginViewModel;
        private IPlayerDtoService _playerDtoService;
        private ILoginController _loginController;
        private IPlayerDao _playerDao;
        private Errors _errors;
        private readonly ILoginViewModel _loginViewModelImplementation;

        private void Start()
        {
            var newLoginView = loginView.AddComponent<LoginView>();
            _loginViewModel = new LoginViewModel();
            newLoginView.Configure(_loginViewModel);
            _playerDao = new PlayerDao(new HttpClient(), new DtosFactory());
            _errors = new Errors();
            var playerDtoService = new PlayerDtoServiceImpl(_playerDao, _errors);
        
            var controller = new LoginController(_loginViewModel, playerDtoService);

            SceneManager.LoadScene("Game");
        }
        
        
    }
}