using System.Net;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using Microsoft.AspNetCore.Identity;
using WEBAPI.Dtos;
using WEBAPI.Helpers;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUnitOfWork unitofWork, IPasswordHasher<User> passwordHasher)
        {
        }
        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                Username = registerDto.Username
            };
            user.Password = _passwordHasher.HashPassword(user, registerDto.Password);//Encrypt password

            var existingUser = _unitOfWork.Users
                                          .Find(u => u.Username.ToLower() == registerDto.Username.ToLower())
                                          .FirstOrDefault();
            if (existingUser == null)
            {
                var rolDefault = _unitOfWork.Roles
                                            .Find(u => u.Nombre == Authorization.rol_default.ToString())
                                            .First();
                try
                {
                    user.Rols.Add(rolDefault);
                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveAsync();

                    return $"User {registerDto.Username} has been registered successfully";
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }
            }
            else
            {
                return $"User {registerDto.Username} already registered";
            }
        }

        public async Task<string> AddRoleAsync(AddRolDto model)
        {
            var user = await _unitOfWork.Users
                                        .GetByUsernameAsync(model.Username);
            if( user == null)
            {
                return $"User {model.Username} does not exists.";
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            if(result == PasswordVerificationResult.Success)
            {
                var rolExists = _unitOfWork.Roles
                                            .Find(u=>u.Nombre.ToLower() == model.Role.ToLower())
                                            .FirstOrDefault();
                if(rolExists != null)
                {
                    var userHasRole = user.Rols
                                            .Any(u => u.Id == rolExists.Id);
                    if(userHasRole == false)
                    {
                        user.Rols.Add(rolExists);
                        _unitOfWork.Users.Update(user);
                        await _unitOfWork.SaveAsync();
                    }
                }
            }
        }

    }
}