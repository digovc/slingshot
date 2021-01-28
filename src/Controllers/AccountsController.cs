using Microsoft.AspNetCore.Mvc;
using Slingshot.Abstractions;
using Slingshot.Models;
using System.Collections.Generic;

namespace Slingshot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository repository;
        private readonly IUserRepository userRepository;

        public AccountsController(IAccountRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        [HttpGet]
        public IEnumerable<AccountModel> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = repository.GetById(id);
            var users = userRepository.GetByAccount(id);

            var result = new
            {
                account,
                users
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountModel account)
        {
            repository.Create(account);

            var result = new
            {
                id = account.Id,
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AccountModel account)
        {
            account.Id = id;
            repository.Alter(account);
        }
    }
}