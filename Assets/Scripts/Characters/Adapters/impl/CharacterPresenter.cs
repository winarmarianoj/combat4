using System;
using System.Collections.Generic;
using Characters.factory;
using Login.DTO.impl;
using Login.Service;
using UniRx;
using UniRx.InternalUtil;

namespace Characters.Adapters.impl
{
    public class CharacterPresenter : ICharacterPresenter
    {
        private readonly ICharacterViewModel _characterViewModel;
        private readonly ICharacterFactory _characterFactory; 
        protected List<IDisposable> _disposables;

        public CharacterPresenter(ICharacterViewModel characterViewModel, IPlayerDtoService playerDtoService, ICharacterFactory characterFactory)
        {
            _characterViewModel = characterViewModel;
            _characterFactory = characterFactory;
            playerDtoService.LoginPlayerDto.Subscribe(Updated).AddTo(_disposables);
        }

        private void Updated(PlayerDto playerDto)
        {
            _characterViewModel.CharacterLocal.Value = _characterFactory.CreateCharacterLocal(playerDto);
            _characterViewModel.CharacterVisitor.Value = _characterFactory.CreateCharacterLoVisitor1();
        }
        
        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
        
        
    }
}