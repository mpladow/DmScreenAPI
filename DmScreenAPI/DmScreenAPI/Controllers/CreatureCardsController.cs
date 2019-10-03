using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Entities;
using AutoMapper;
using DmScreenAPI.Dtos;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatureCardsController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public CreatureCardsController(DatabaseContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        // GET: api/CreatureCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatureCard>>> GetCreatureCards()
        {
            var xx = await _db.CreatureCards.Where(cc => cc.isHostile).ToListAsync();
            return await _db.CreatureCards.Where(cc => cc.isHostile).ToListAsync();
        }

        // GET: api/CreatureCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreatureCard>> GetCreatureCard(int id)
        {
            var creatureCard = await _db.CreatureCards.FindAsync(id);

            if (creatureCard == null)
            {
                return NotFound();
            }

            return creatureCard;
        }


        // POST: api/CreatureCards
        [HttpPost("edit")]
        public async Task<ActionResult<CreatureCardDto>> Edit(CreatureCardDto creatureCard)
        {
            var idToReturn = 0;
            var creatureCardInDb = _db.CreatureCards.FirstOrDefault(cc => cc.CreatureCardId == creatureCard.CreatureCardId);
            if (creatureCardInDb != null)
            {
                // edit this creature card
                _mapper.Map(creatureCard, creatureCardInDb);
                creatureCard.Actions.ForEach(a =>
                {
                    // remove all existing creatureCard Entries
                    var action = new CreatureAction();
                    action.Name = a.Name;
                    action.Description = a.Description;
                    _db.CreatureAction.Add(action);
                    _db.SaveChanges();
                    var actionsToRemove = _db.CreatureCardActions.Where(cca => cca.CreatureCardId == creatureCard.CreatureCardId).ToList();
                    _db.CreatureCardActions.RemoveRange(actionsToRemove);
                    //add entry to linking table
                    var creatureCardAction = new CreatureCardAction();
                    creatureCardAction.CreatureActionId = action.CreatureActionId;
                    creatureCardAction.CreatureCardId = creatureCard.CreatureCardId;
                    _db.CreatureCardActions.Add(creatureCardAction);
                });
                idToReturn = creatureCardInDb.CreatureCardId;
                creatureCard.CreatureCardId = creatureCardInDb.CreatureCardId;

            }
            else
            {
                var creature = _mapper.Map<CreatureCard>(creatureCard);
                
                _db.CreatureCards.Add(creature);
                _db.CreatureAction.AddRange(creature.Actions);
                _db.SaveChanges();
                // add the actions to the creature card
                creature.Actions.ForEach(a =>
                {
                    //var action = new CreatureAction();
                    //action.Name = a.Name;
                    //action.Description = a.Description;
                    //_db.CreatureAction.Add(action);
                    _db.SaveChanges();
                    //add entry to linking table
                    var creatureCardAction = new CreatureCardAction();
                    creatureCardAction.CreatureActionId = a.CreatureActionId;
                    creatureCardAction.CreatureCardId = creature.CreatureCardId;
                    _db.CreatureCardActions.Add(creatureCardAction);
                });
                idToReturn = creature.CreatureCardId;
            }
            _db.SaveChanges();

            return CreatedAtAction("Edit", new { id = idToReturn}, creatureCard);
        }

        // DELETE: api/CreatureCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CreatureCard>> DeleteCreatureCard(int id)
        {
            var creatureCard = await _db.CreatureCards.FindAsync(id);
            if (creatureCard == null)
            {
                return NotFound();
            }

            _db.CreatureCards.Remove(creatureCard);
            await _db.SaveChangesAsync();

            return creatureCard;
        }

        private bool CreatureCardExists(int id)
        {
            return _db.CreatureCards.Any(e => e.CreatureCardId == id);
        }
    }
}
