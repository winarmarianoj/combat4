using System;
using System.Threading.Tasks;
using Exception;
using Login.DAO;
using Login.DTO.impl;
using UniRx;

namespace Login.Service.impl
{ 
    public class PlayerDtoServiceImpl : IPlayerDtoService
    {
        public ReactiveProperty<PlayerDto> LoginPlayerDto { get; set; }

        private readonly IPlayerDao _dao;
        private readonly Errors _errors;

        public PlayerDtoServiceImpl(IPlayerDao dao, Errors errors)
        {
            _dao = dao;
            _errors = errors;
        }

        public async Task<PlayerDto> Login(string nickName)
        {
            try
            {
                var response = await _dao.LoginPlayer(nickName);
                SendPlayerDto(response);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                await _errors.LogErrors(e.Message);
            }
            
            return LoginPlayerDto.Value;
        }
        
        private void SendPlayerDto(PlayerDto playerDto)
        {
            LoginPlayerDto.Value = playerDto;
            LoginPlayerDto = new ReactiveProperty<PlayerDto>(LoginPlayerDto.Value);
        }
        
    }
}