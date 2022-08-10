using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElevenNote_WebApp.Server.Services.NoteServices;
using ElevenNote_WebApp.Shared.Models.NoteModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElevenNote_WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteEntityController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteEntityController(INoteService _noteService)
        {
            this._noteService = _noteService;
        }

        private string GetUserID()
        {
            string userIDClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIDClaim == null) return null;

            return userIDClaim;
        }

        private bool SetUserIdInService()
        {
            var userID = GetUserID();
            if (userID == null) return false;

            _noteService.SetUserID(userID);
            return true;
        }
        
        // GET: api/values
        [HttpGet]
        public async Task<List<NoteListItem>> Index()
        {
            if (!SetUserIdInService()) return new List<NoteListItem>();

            var notes = await _noteService.GetAllNotesAsync();
            return notes.ToList();
        }

        // GET api/values/5
        [HttpGet("{NoteID}")]
        public async Task<IActionResult> Note (int noteID)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var note = await _noteService.GetNoteByIdAsync(noteID);
            if (note == null) return NotFound();

            return Ok(note);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create(NoteCreate model)
        {
            if (model == null) return BadRequest();
            if (!SetUserIdInService()) return Unauthorized();

            if (await _noteService.CreateNoteAsync(model)) return Ok();
            else
                return UnprocessableEntity();
        }

        // PUT api/values/5
        [HttpPut("edit/{NoteID}")]
        public async Task<IActionResult> Edit (int noteID, NoteEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();
            if (model.ID != noteID) return BadRequest();

            if (await _noteService.UpdateNoteAsync(model)) return Ok();
            else
                return BadRequest();

        }

        // DELETE api/values/5
        [HttpDelete("{NoteID}")]
        public async Task<IActionResult> Delete(int noteID)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var note = await _noteService.GetNoteByIdAsync(noteID);
            if (note == null) return NotFound();

            if (await _noteService.DeleteNoteAsync(note.ID)) return Ok();
            else
                return BadRequest();
             
        }
    }
}

