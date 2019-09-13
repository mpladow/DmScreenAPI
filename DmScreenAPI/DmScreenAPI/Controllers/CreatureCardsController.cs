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
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreatureCardsController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CreatureCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatureCard>>> GetCreatureCards()
        {
            return await _context.CreatureCards.ToListAsync();
        }

        // GET: api/CreatureCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreatureCard>> GetCreatureCard(int id)
        {
            var creatureCard = await _context.CreatureCards.FindAsync(id);

            if (creatureCard == null)
            {
                return NotFound();
            }

            return creatureCard;
        }


        // POST: api/CreatureCards
        [HttpPost("edit")]
        public async Task<ActionResult<CreatureCard>> Edit(CreatureCardDto creatureCard)
        {
            var idToReturn = 0;
            var creatureToReturn = new CreatureCard();
            var creatureCardInDb = _context.CreatureCards.FirstOrDefault(cc => cc.CreatureCardId == creatureCard.CreatureCardId);
            if (creatureCardInDb != null)
            {
                // edit this creature card
                _mapper.Map(creatureCard, creatureCardInDb);
                var added = creatureCard.Actions.Except(creatureCardInDb.Actions).ToList();
                var deleted = creatureCardInDb.Actions.Except(creatureCard.Actions).ToList();
                added.ForEach(a =>
                {
                    var creatureCardAction = new CreatureCardAction();
                    creatureCardAction.CreatureActionId = a.CreatureActionId;
                    creatureCardAction.CreatureCardId = creatureCardInDb.CreatureCardId;
                    _context.CreatureCardActions.Add(creatureCardAction);
                });
                deleted.ForEach(d =>
                {
                    var creatureCardActionInDb = _context.CreatureCardActions.Where(cca => cca.CreatureActionId == d.CreatureActionId).FirstOrDefault();
                    _context.CreatureCardActions.Remove(creatureCardActionInDb);
                });
                idToReturn = creatureCardInDb.CreatureCardId;
                creatureToReturn = creatureCardInDb;
            }
            else
            {
                var creature = _mapper.Map<CreatureCard>(creatureCard);
                _context.CreatureCards.Add(creature);
                _context.SaveChanges();
                // add the actions to the creature card
                creatureCard.Actions.ForEach(a =>
                {
                    var action = new CreatureAction();
                    action.Name = a.Name;
                    action.Description = a.Description;
                    _context.CreatureAction.Add(action);
                    _context.SaveChanges();
                    //add entry to linking table
                    var creatureCardAction = new CreatureCardAction();
                    creatureCardAction.CreatureActionId = action.CreatureActionId;
                    creatureCardAction.CreatureCardId = creature.CreatureCardId;
                    _context.CreatureCardActions.Add(creatureCardAction);
                });
                idToReturn = creature.CreatureCardId;
                creatureToReturn = creature;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("Edit", new { id = idToReturn}, creatureToReturn);
        }

        // DELETE: api/CreatureCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CreatureCard>> DeleteCreatureCard(int id)
        {
            var creatureCard = await _context.CreatureCards.FindAsync(id);
            if (creatureCard == null)
            {
                return NotFound();
            }

            _context.CreatureCards.Remove(creatureCard);
            await _context.SaveChangesAsync();

            return creatureCard;
        }

        private bool CreatureCardExists(int id)
        {
            return _context.CreatureCards.Any(e => e.CreatureCardId == id);
        }
    }
}
