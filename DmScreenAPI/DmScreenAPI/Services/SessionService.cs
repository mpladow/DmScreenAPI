using AutoMapper;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Services
{
    public class SessionService
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public SessionService(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public SessionDto GetSessionDetails(int id)
        {
            var sessionDto = new SessionDto();
            //var cardActions = _db.CreatureAction.Where(ca => ca.CreatureCard.AccountCreatureCard.Any(acc => acc.AccountId == id)).;
            var creatureCards = _db.AccountCreatureCards
                .Where(cc => cc.AccountId == id)
                .Include(x => x.CreatureCard.Actions)
            .Select(cc => new CreatureCardDto()
            {
                Name = cc.CreatureCard.Name,
                AC = cc.CreatureCard.AC,
                Initiative = cc.CreatureCard.Initiative,
                isHostile =cc.CreatureCard.isHostile,
                CurrentHP = cc.CreatureCard.CurrentHP,
                MaxHP = cc.CreatureCard.MaxHP,
                PPerception = cc.CreatureCard.PPerception,
                PInsight = cc.CreatureCard.PInsight,
                PInvestigation = cc.CreatureCard.PInvestigation,
                Strength = cc.CreatureCard.Strength,
                Dexterity = cc.CreatureCard.Dexterity,
                Wisdom = cc.CreatureCard.Wisdom,
                Intelligence = cc.CreatureCard.Intelligence,
                Constitution = cc.CreatureCard.Constitution,
                Notes = cc.CreatureCard.Notes,
                RedIndicatorOn = cc.CreatureCard.RedIndicatorOn,
                GreenIndicatorOn = cc.CreatureCard.GreenIndicatorOn,
                BlueIndicatorOn = cc.CreatureCard.BlueIndicatorOn,
                Actions = _mapper.Map<List<CreatureActionDto>>(cc.CreatureCard.Actions)
            }).ToList();
            //add the actions
            sessionDto.CreatureCards.AddRange(creatureCards);

            var resources = _db.AccountResources
                .Where(ar => ar.AccountId == id)
                .Include(i => i.Resources)
                .ToList();
            if (resources.Count != 0)
            {
                resources.ForEach(r =>
                {
                    var resource = _db.Resources.FirstOrDefault(x => x.ResourceId == r.ResourceId);
                    var dto = _mapper.Map<ResourceDto>(resource);
                    sessionDto.Resources.Add(dto);
                });

            }

            return sessionDto;
        }
    }
}
