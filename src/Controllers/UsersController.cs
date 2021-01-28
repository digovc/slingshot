using Microsoft.AspNetCore.Mvc;
using Slingshot.Abstractions;
using Slingshot.Models;
using System.Collections.Generic;

namespace Slingshot.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpDelete("{id}")]
        public void Delete(int accountId, int id)
        {
            repository.Delete(accountId, id);
        }

        [HttpGet]
        public IEnumerable<UserModel> Get(int accountId)
        {
            return repository.GetByAccount(accountId);
        }

        [HttpGet("{id}")]
        public UserModel Get(int accountId, int id)
        {
            return repository.GetById(accountId, id);
        }

        [HttpPost]
        public void Post(int accountId, [FromBody] UserModel user)
        {
            repository.Create(accountId, user);
        }

        [HttpPut("{id}")]
        public void Put(int accountId, int id, [FromBody] UserModel user)
        {
            repository.Alter(accountId, id, user);
        }
    }
}