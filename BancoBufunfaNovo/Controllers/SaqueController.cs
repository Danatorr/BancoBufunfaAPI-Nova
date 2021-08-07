using BancoBufunfaNovo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoBufunfaNovo.Controllers
{
    public class SaqueController : ControllerBase
    {
        private readonly BancoBufunfaNovoContext _context;

        public SaqueController(BancoBufunfaNovoContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Saque(int id, int valor)
        {
            //Checando caso a conta existe, caso null retornar notfound
            var conta = _context.Conta.FirstOrDefault(x => x.Id == id);
            if (conta == null)
            {
                return NotFound($"A conta com o id {id} não pode ser achada!");
            }
            conta.Saldo -= valor;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
