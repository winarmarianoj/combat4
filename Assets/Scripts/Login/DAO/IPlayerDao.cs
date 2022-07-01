using System.Threading.Tasks;
using Login.DTO.impl;

namespace Login.DAO
{
    public interface IPlayerDao
    {
       Task<PlayerDto> LoginPlayer(string nickName);
    }
}