using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ventory.application.Exceptions;
using ventory.application.models;
using ventory.infrastructure.Data;
using ventory.domain.Entities.UserAgg;
using ventory.domain.Entities.CompanyAgg;
using Microsoft.AspNetCore.Identity;
namespace ventory.application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly VentoryDbContext ventoryDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(VentoryDbContext ventoryDbContext, IPasswordHasher<User> passwordHasher)
        {
            this._passwordHasher = passwordHasher;
            this.ventoryDbContext = ventoryDbContext;
        }
        public async  Task<bool> RegisterUserAsync(NewUserModel newUserModel)
        {
            if (await isEmailUniqueAsync(newUserModel.Email))
            {
                throw new EmailExistException(newUserModel.Email);
            }

            var user = new User
            {
                FirstName = newUserModel.FirstName,
                LastName = newUserModel.LastName,
                Email = newUserModel.Email,
                PasswordHash = hashPassword(newUserModel.Password),
                Company = new Company
                {
                    Name = newUserModel.CompanyName
                }
            };
            await ventoryDbContext.Users.AddAsync(user);
            return await ventoryDbContext.SaveChangesAsync() > 0;
        }


        private async Task<bool> isEmailUniqueAsync(string email)
        {
            return  await ventoryDbContext.Users.AnyAsync(x => x.Email == email);
        }

        private string hashPassword(string password)
        {
            return _passwordHasher.HashPassword(null,password);
        }

        private PasswordVerificationResult verifyPassword(string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(null,hashedPassword,providedPassword);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await ventoryDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            ventoryDbContext.Users.Remove(user);
            return await ventoryDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await isEmailUniqueAsync(email);   
        }
    }
}