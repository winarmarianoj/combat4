using Login.Adapters;
using Login.Adapters.impl;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Login.View.impl
{
    public class LoginView : MonoBehaviour, ILoginView
    {
        [SerializeField] private TMP_InputField nickNameFront;
        [SerializeField] private Button nickNameButton;

        private ILoginViewModel _loginViewModel;

        public void Configure(ILoginViewModel model)
        {
            _loginViewModel = model;

            nickNameButton
                .onClick
                .AddListener(() => { _loginViewModel.LoginNickNameButton.Execute(nickNameFront.text);});

            /*nickNameButton.OnClickAsObservable()
                .Subscribe( (_) => { _loginViewModel.LoginNickNameButton.Execute(nickName.text); });*/
            
            //_loginViewModel.LoginNickName.Subscribe(Loged);
        }

        private void LogedNickname(string nickname)
        {
            _loginViewModel.LoginNickName.Value = nickNameFront.text;
        }

        public void LoginNickname()
        {
            _loginViewModel.Login(nickNameFront.text);
        }
    }
}