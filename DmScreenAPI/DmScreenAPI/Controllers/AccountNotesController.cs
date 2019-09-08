using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Entities;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountNotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccountNotesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AccountNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountNotes>>> GetAccountNotes()
        {
            return await _context.AccountNotes.ToListAsync();
        }

        // GET: api/AccountNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountNotes>> GetAccountNotesByAcountId(int id)
        {
            var accountNotes = await _context.AccountNotes.Where(x=>x.AccountId == id).FirstOrDefaultAsync();

            return accountNotes;
        }

        // PUT: api/AccountNotes/5
        [HttpPost("edit")]
        public async Task<IActionResult> EditAccountNotes(AccountNotes accountNotes)
        {
            var entity = new AccountNotes();
            var accountNoteInDb = _context.AccountNotes.FirstOrDefault(r => r.AccountNotesId == accountNotes.AccountNotesId);
            if (accountNoteInDb == null)
            {
                _context.Add(accountNotes);
                _context.SaveChanges();
                return Ok(entity);
            }
            else
            {
                accountNoteInDb.Notes = accountNotes.Notes;
                _context.SaveChanges();
                return Ok(entity);
            }
        }

        // POST: api/AccountNotes
        [HttpPost]
        public async Task<ActionResult<AccountNotes>> PostAccountNotes(AccountNotes accountNotes)
        {
            _context.AccountNotes.Add(accountNotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountNotes", new { id = accountNotes.AccountNotesId }, accountNotes);
        }

        // DELETE: api/AccountNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountNotes>> DeleteAccountNotes(int id)
        {
            var accountNotes = await _context.AccountNotes.FindAsync(id);
            if (accountNotes == null)
            {
                return NotFound();
            }

            _context.AccountNotes.Remove(accountNotes);
            await _context.SaveChangesAsync();

            return accountNotes;
        }

        private bool AccountNotesExists(int id)
        {
            return _context.AccountNotes.Any(e => e.AccountNotesId == id);
        }
    }
}
