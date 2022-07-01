using Login.DTO.impl;

namespace Login.Factory
{
    public interface IDtosFactory
    {
        LoginDto CreateLoginDto(string nickName);
    }
}