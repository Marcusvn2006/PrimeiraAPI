using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Data;
using PrimeiraAPI.Models;

namespace PrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly MyContext _context;

        public TurmasController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Turmas

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }
            return await _context.Turmas.ToListAsync();
        }
        // GET: api/Turmas

        [HttpGet("api/TurmasPaginas")]
        public async Task<ActionResult<IEnumerable<Turma>>> ListaPaginadasssTurmas(int qtdRegistro, int nrPagina)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }
            return await _context.Turmas.Skip(qtdRegistro * nrPagina).ToListAsync();
        }

        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        // PUT: api/Turmas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Turmas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            if (_context.Turmas == null)
            {
                return Problem("Entity set 'MyContext.Turmas'  is null.");
            }
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.TurmaId }, turma);
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turmas == null)
            {
                return NotFound();
            }
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turmas?.Any(e => e.TurmaId == id)).GetValueOrDefault();
        }
    }
}
