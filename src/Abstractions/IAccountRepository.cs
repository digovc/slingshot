using Slingshot.Models;
using System.Collections.Generic;

namespace Slingshot.Abstractions
{
    public interface IAccountRepository
    {
        void Alter(AccountModel account);

        void Create(AccountModel account);

        void Delete(int id);

        IEnumerable<AccountModel> GetAll();

        AccountModel GetById(int id);
    }
}