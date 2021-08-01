using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoBufunfaNovo.Data;
using BancoBufunfaNovo.Models;

namespace BancoBufunfaNovo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly BancoBufunfaNovoContext _context;

        public ContasController(BancoBufunfaNovoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetConta()
        {
            return await _context.Conta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
            //Checando caso a conta não é null, caso sim, retornar not found
            var conta = await _context.Conta.FindAsync(id);

            if (conta == null)
            {
                return NotFound($"A conta com id {id} não pode ser achada!");
            }

            return conta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, Conta conta)
        {
            if (id != conta.Id)
            {
                return BadRequest();
            }

            _context.Entry(conta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(id))
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

        //Create conta
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            _context.Conta.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConta", new { id = conta.Id }, conta);
        }

        //Deletar conta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            //Checando caso a conta existe, caso null retornar notfound
            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound($"A conta com o id {id} não pode ser achada!");
            }

            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.Id == id);
        }
    }
}
