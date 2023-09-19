using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventory.application.models;

namespace ventory.application.Services.Users
{
    public interface IUserService
    {
        //implement the interface

        public Task<bool> RegisterUserAsync(NewUserModel newUserModel);

        public Task<bool> IsEmailUniqueAsync(string email);

        public Task<bool> DeleteUserAsync(Guid userId);


    }
}