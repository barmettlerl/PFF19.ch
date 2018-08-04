using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;

namespace pff19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantsController : ApiControllerBase
    {
        private const string GetAssistantRouteName = "GetAssistants";
        private readonly AssistantRepository _assistantsRepository;

        public AssistantsController(AssistantRepository assistantRepository)
        {
            _assistantsRepository = assistantRepository;
        }

        // GET: api/Assistants
        [HttpGet]
        public IEnumerable<Assistant> Get()
        {
            return _assistantsRepository.GetAll().ToList();
        }

        // GET: api/Assistants/5
        [HttpGet("{id}", Name = GetAssistantRouteName)]
        public Assistant Get(int id)
        {
            return _assistantsRepository.Get(id);
        }

        // POST: api/Assistants
        [HttpPost, Authorize]
        public IActionResult Post(Assistant assistant)
        {
            _assistantsRepository.Add(assistant);
            return CreatedAtRoute(GetAssistantRouteName, new { id = assistant.Id }, assistant);
        }

        // PUT: api/Assistants/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, Assistant assistant)
        {
            var existingAssistant = _assistantsRepository.Get(id);
            if (existingAssistant == null)
            {
                return NotFound();
            }

            existingAssistant.Name = assistant.Name;
            existingAssistant.Pfadiname = assistant.Pfadiname;
            existingAssistant.Vorname = assistant.Vorname;
            existingAssistant.Wishes = assistant.Wishes;

            _assistantsRepository.Update(existingAssistant);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var existingAssistant = _assistantsRepository.Get(id);
            if (existingAssistant == null)
            {
                return NotFound();
            }

            _assistantsRepository.Delete(existingAssistant);

            return NoContent();
        }
    }
}