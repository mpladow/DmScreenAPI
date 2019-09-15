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
            var creatureCards = _db.AccountCreatureCards
                .Where(ac => ac.AccountId == id)
                .Include(x=> x.CreatureCards)
                .ToList();
            if (creatureCards.Count != 0)
            {
                creatureCards.ForEach(cc =>
                {
                    var creatureCard = _db.CreatureCards.FirstOrDefault(x => x.CreatureCardId == cc.CreatureCardId);
                    var dto = _mapper.Map<CreatureCardDto>(creatureCard);
                    sessionDto.CreatureCards.Add(dto);
                });
            }
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
