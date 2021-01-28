using LiteDB;
using Slingshot.Models;

namespace Slingshot.Abstractions
{
    public interface IDatabase
    {
        ILiteCollection<T> GetColletion<T>() where T : ModelBase;
    }
}