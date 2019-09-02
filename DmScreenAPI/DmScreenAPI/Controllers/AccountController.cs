using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using DmScreenAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DmScreenAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public AccountController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Index()
        {
            var resourceList = _db.Accounts.Select(r => new AccountDto
            {
                AccountId = r.AccountId,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email
            }).ToList();
            return Ok(resourceList);
        }
        [HttpGet("{id}")]
        public ActionResult Edit(int id)
        {
            var resourceInDb = _db.Accounts.FirstOrDefault(r => r.AccountId == id);
            if (resourceInDb == null)
            {
                return BadRequest();
            }
            var dto = _mapper.Map<AccountDto>(resourceInDb);
            return Ok(dto);
        }
        [HttpPost("edit")]
        public ActionResult Edit(AccountDto accountDto)
        {
            var accountinDb = _db.Accounts.FirstOrDefault(r => r.AccountId == accountDto.AccountId);
            if (accountinDb == null)
            {
                var entity = _mapper.Map<Account>(accountDto);
                _db.Add(entity);
            }
            else
            {
                _mapper.Map(accountDto, accountinDb);
            }
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var accountInDb = _db.Accounts.FirstOrDefault(r => r.AccountId == id);
            _db.Remove(accountInDb);
            _db.SaveChanges();
            return Ok();
        }
    }
}