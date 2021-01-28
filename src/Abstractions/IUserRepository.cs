using Slingshot.Models;
using System.Collections.Generic;

namespace Slingshot.Abstractions
{
    public interface IUserRepository
    {
        void Alter(int accountId, int id, UserModel user);

        void Create(int accountId, UserModel user);

        void Delete(int accountId, int id);

        void DeleteByAccount(int accountId);

        IEnumerable<UserModel> GetAll();

        IEnumerable<UserModel> GetByAccount(int accountId);

        UserModel GetById(int accountId, int id);
    }
}