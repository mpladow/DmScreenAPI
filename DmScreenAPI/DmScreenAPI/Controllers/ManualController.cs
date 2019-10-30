using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using DmScreenAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManualController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        private readonly UtilitiesService _utilities;

        public ManualController(DatabaseContext context, IMapper mapper, UtilitiesService utilities)
        {
            _db = context;
            _mapper = mapper;
            _utilities = utilities;
        }
        // GET: api/Manual
        [HttpGet]
        public IActionResult Get()
        {
            var query = _db.ManualItems.Where(mi => mi.DeletedAt == null)
                .ToList();
            var dtoList = new List<ManualItemDto>();
            query.ForEach(mi =>
            {
                var dto = new ManualItemDto();
                _utilities.AutoMap(ref dto, mi);
                dtoList.Add(dto);
            });
            return Ok(dtoList);
        }

        // GET: api/Manual/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var entityInDb = _db.ManualItems
                .Where(mi => mi.DeletedAt == null)
                .FirstOrDefault(mi => mi.ManualItemId == id);
            var dto = new ManualItemDto();

            if (entityInDb == null)
                return BadRequest();
            else
                _utilities.AutoMap<ManualItemDto>(ref dto, entityInDb);
            return Ok(dto);
        }

        // POST: api/Manual
        [HttpPost]
        public IActionResult Post(ManualItemDto model)
        {
            if (model.ManualItemId > 0)
            {
                var entityInDb = _db.ManualItems.FirstOrDefault(mi => mi.ManualItemId == model.ManualItemId);

                _mapper.Map(model, entityInDb);
                _db.SaveChanges();

            }
            else
            {
                var entity = new ManualItem();
                //_mapper.Map(model, entity);
                _utilities.AutoMap(ref entity, model);
                _db.Add(entity);
                _db.SaveChanges();
                model.ManualItemId = entity.ManualItemId;

            }
            return Ok(model);
        }

        // PUT: api/Manual/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entityInDb = _db.ManualItems.Find(id);
            if (entityInDb == null)
            {
                return BadRequest();
            }
            else
            {
                _db.ManualItems.Remove(entityInDb);
            }
            return Ok(entityInDb);
        }
    }
}
