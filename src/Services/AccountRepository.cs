using LiteDB;
using Slingshot.Abstractions;
using Slingshot.Models;
using System.Collections.Generic;

namespace Slingshot.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabase database;
        private readonly IUserRepository userRepository;

        public AccountRepository(IDatabase database, IUserRepository userRepository)
        {
            this.database = database;
            this.userRepository = userRepository;
        }

        void IAccountRepository.Alter(AccountModel account)
        {
            var colletion = GetCollection();
            colletion.Update(account);
        }

        void IAccountRepository.Create(AccountModel account)
        {
            var colletion = GetCollection();
            colletion.Insert(account);
        }

        void IAccountRepository.Delete(int id)
        {
            userRepository.DeleteByAccount(id);
            var colletion = GetCollection();
            colletion.Delete(id);
        }

        IEnumerable<AccountModel> IAccountRepository.GetAll()
        {
            var colletion = GetCollection();
            return colletion.FindAll();
        }

        AccountModel IAccountRepository.GetById(int id)
        {
            var colletion = GetCollection();
            return colletion.FindById(id);
        }

        private ILiteCollection<AccountModel> GetCollection()
        {
            return database.GetColletion<AccountModel>();
        }
    }
}