using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using DmScreenAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountResourceController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountResourceController(IAccountRepository repo)
        {
            _accountRepository = repo;
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            //var accountResources = _db.AccountResources
            //    .Where(ar => ar.AccountId == id)
            //    .Select(ar => new AccountResourceDto
            //    {
            //        AccountId = id,
            //        AccountResourceId = ar.AccountResourceId,
            //        Resources = ar.Resources.Where(r => r.Id == ar.ResourceId)
            //        .ToList()
            //        .Select(s => new ResourceDto
            //        {
            //            Id = s.Id,
            //            Category = s.Category,
            //            Html = s.Html
            //        }).ToList()
            //    }); ;
            //// hash the password
            return Ok();

        }
        [HttpPost("save")]
        public IActionResult Save(AccountResourceDto model)
        {
            //find existing resources and delete them 
            var resourcesOwnedByAccount = _accountRepository.GetAccountResources(model.AccountId);
            // create the entity
            if (resourcesOwnedByAccount.Count() > 0)
            {
                _accountRepository.RemoveAccountResources(resourcesOwnedByAccount);
            }

            for (int i = 0; i < model.Resources.Count(); i++)
            {
                var accountResourceEntity = new AccountResource
                {
                    AccountId = model.AccountId,
                    ResourceId = model.Resources[i].ResourceId,
                    Sequence = i
                };
                _accountRepository.Add(accountResourceEntity);

            }
            return Ok();
        }


    }
}