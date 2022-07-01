using System.Threading.Tasks;
using Login.DTO.impl;
using UniRx;

namespace Login.Service
{
    public interface IPlayerDtoService
    {
        Task<PlayerDto> Login(string nickName);
        ReactiveProperty<PlayerDto> LoginPlayerDto { get; }
    }
}