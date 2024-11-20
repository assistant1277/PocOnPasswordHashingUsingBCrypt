using PasswordHashing.Dtos;

namespace PasswordHashing.Services
{
    public interface IUserService
    {
        void Register(UserDto userDto);
        void Login(LoginDto loginDto);
    }
}