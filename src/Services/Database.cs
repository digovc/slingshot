using LiteDB;
using Slingshot.Abstractions;

namespace Slingshot.Services
{
    public class Database : IDatabase
    {
        private readonly ILiteDatabase _database;

        public Database()
        {
            _database = new LiteDatabase("./database.db");
        }

        ILiteCollection<T> IDatabase.GetColletion<T>()
        {
            return _database.GetCollection<T>();
        }
    }
}