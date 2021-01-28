using LiteDB;
using Slingshot.Abstractions;
using Slingshot.Models;
using System;
using System.Collections.Generic;

namespace Slingshot.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabase database;

        public UserRepository(IDatabase database)
        {
            this.database = database;
        }

        void IUserRepository.Alter(int accountId, int id, UserModel user)
        {
            user.Id = id;
            user.AccountId = accountId;
            var colletion = GetCollection();
            colletion.Update(user);
        }

        void IUserRepository.Create(int accountId, UserModel user)
        {
            user.AccountId = accountId;
            var colletion = GetCollection();
            ValidateEmail(user, colletion);
            colletion.Insert(user);
        }

        void IUserRepository.Delete(int accountId, int id)
        {
            var colletion = GetCollection();
            colletion.Delete(id);
        }

        void IUserRepository.DeleteByAccount(int accountId)
        {
            var colletion = GetCollection();
            colletion.DeleteMany(x => x.AccountId == accountId);
        }

        IEnumerable<UserModel> IUserRepository.GetAll()
        {
            var colletion = GetCollection();
            return colletion.FindAll();
        }

        IEnumerable<UserModel> IUserRepository.GetByAccount(int accountId)
        {
            var colletion = GetCollection();
            return colletion.Query().Where(x => x.AccountId == accountId).ToEnumerable();
        }

        UserModel IUserRepository.GetById(int accountId, int id)
        {
            var colletion = GetCollection();
            return colletion.FindById(id);
        }

        private ILiteCollection<UserModel> GetCollection()
        {
            return database.GetColletion<UserModel>();
        }

        private void ValidateEmail(UserModel user, ILiteCollection<UserModel> colletion)
        {
            var oldUser = colletion.FindOne(x => x.Email == user.Email && x.Id != user.Id);

            if (oldUser != null)
            {
                throw new InvalidOperationException("Email already in use.");
            }
        }
    }
}