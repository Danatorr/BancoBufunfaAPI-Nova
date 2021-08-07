using BancoBufunfaNovo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoBufunfaNovo.Controllers
{
    public class DepositoController : ControllerBase
    {
        private readonly BancoBufunfaNovoContext _context;

        public DepositoController(BancoBufunfaNovoContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Deposito(int id, int valor)
        {
            var conta = _context.Conta.FirstOrDefault(x => x.Id == id);
            if (conta == null)
            {
                return NotFound($"A conta com o id {id} não pode ser achada!");
            }
            conta.Saldo += valor;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
