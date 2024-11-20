using AutoMapper;
using PasswordHashing.Dtos;
using PasswordHashing.Exceptions;
using PasswordHashing.Models;
using PasswordHashing.Repositories;

namespace PasswordHashing.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        //here we are doing like register user by hashing password and adding user to database
        public void Register(UserDto userDto)
        {
            //check if user already exists
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.UserName == userDto.UserName);
            if (existingUser != null)
            {
                throw new UserAlreadyExistException("Username already exists");
            }

            //hashing password using bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userDto.UserName,
                PasswordHash = hashedPassword,
                Email = userDto.Email
            };
            _userRepository.Add(user);
            _userRepository.Save();
        }

        //here we are doing like login user by checking password against stored hash
        public void Login(LoginDto loginDto)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == loginDto.UserName);
            if (user == null)
            {
                throw new UserNotFoundException("Invalid credentials means no user found");
            }

            //here we are doing like verifying password with hash stored in database
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new UserNotFoundException("Invalid credentials");
            }
        }
    }
}