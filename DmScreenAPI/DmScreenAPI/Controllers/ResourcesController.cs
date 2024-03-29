﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public ResourcesController(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Index()
        {

            var resourceList = _db.Resources.Select(r => new ResourceDto
            {
                ResourceId = r.ResourceId,
                Category = r.Category,
                Html = r.Html
            }).ToList();
            return Ok(resourceList);
        }
        [HttpGet("{id}")]
        public ActionResult Edit(int id)
        {
            var resourceInDb = _db.Resources.FirstOrDefault(r => r.ResourceId == id);
            if (resourceInDb == null)
            {
                return BadRequest();
            }
            var dto = _mapper.Map<ResourceDto>(resourceInDb);
            return Ok(dto);
        }
        [HttpPost("edit")]
        public ActionResult Edit(ResourceDto resourceDto)
        {
            var entity = new Resource();
            var resourceinDb = _db.Resources.FirstOrDefault(r => r.ResourceId == resourceDto.ResourceId);
            if (resourceinDb == null)
            {
                entity = _mapper.Map<Resource>(resourceDto);
                _db.Add(entity);
                _db.SaveChanges();
                return Ok(entity);
            }
            else
            {
                _mapper.Map(resourceDto, resourceinDb);
                _db.SaveChanges();
                return Ok(entity);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var resourceinDb = _db.Resources.FirstOrDefault(r => r.ResourceId == id);
            _db.Remove(resourceinDb);
            _db.SaveChanges();
            return Ok();
        }
    }
}