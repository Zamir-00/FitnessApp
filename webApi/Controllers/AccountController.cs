using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApi.DbOperations;
using webApi.SessionOperations.GetSessions;


namespace webApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class AccountController : ControllerBase
    {
        private readonly FitnessAppDbContext _context;

        public AccountController (FitnessAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{accountName}")]
        public IActionResult GetByAccountName(string accountName, string password){
            var account = _context.Accounts.Where(account => account.accountName == accountName).SingleOrDefault();
            if (account.password != password)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}