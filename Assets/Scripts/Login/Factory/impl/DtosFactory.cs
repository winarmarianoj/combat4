
using Login.DTO.impl;

namespace Login.Factory.impl
{
    public class DtosFactory : IDtosFactory
    {
        public LoginDto CreateLoginDto(string nickName)
        {
            LoginDto dto = new LoginDto();
            dto.nickname = nickName;
            return dto;
        }
    }
}