using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SessionController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AccountNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> Get()
        {
            return null;
        }
        [HttpPost("Edit")]
        public ActionResult Edit(SessionDto session)
        {
            var accountCreatureCardsInDb = _context.AccountCreatureCards.Where(acc => acc.AccountId == session.AccountId).ToList();
            var accountResourcesInDb = _context.AccountResources.Where(ar => ar.AccountId == session.AccountId).ToList();
            if (accountCreatureCardsInDb.Count > 0)
            {
                _context.AccountCreatureCards.RemoveRange(accountCreatureCardsInDb);
            }
            if (accountResourcesInDb.Count > 0)
            {
                _context.AccountResources.RemoveRange(accountResourcesInDb);
            }
            _context.SaveChanges();

            session.CreatureCards.ForEach(cc =>
            {
                var entity = new AccountCreatureCard();

                entity.AccountId = session.AccountId;
                entity.CreatureCardId = cc.CreatureCardId;
                _context.AccountCreatureCards.Add(entity);
            });
            session.Resources.ForEach(r =>
            {
                var entity = new AccountResource();

                entity.AccountId = session.AccountId;
                entity.ResourceId = r.ResourceId;
                _context.AccountResources.Add(entity);
            });

            _context.SaveChanges();
            return Ok();
        }
    }
}