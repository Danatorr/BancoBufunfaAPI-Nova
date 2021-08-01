﻿using System;
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
    /*
    private IClienteData _clienteData;
    public ClienteController(IClienteData clienteData)
    {
        _clienteData = clienteData;
    }
    */
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BancoBufunfaNovoContext _context;

        public ClientesController(BancoBufunfaNovoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }
        //Read
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            //Buscando cliente, caso null retornar notfound
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound($"O cliente com id {id} não pode ser achado!");
            }

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            //Buscando cliente, caso null retornar badrequest
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        //Create
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            //Buscando o cliente, caso não exista retornar um notfound
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound($"O cliente com id {id} não pode ser achado!");
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
        /*
         *  TODO: Implementar Patch (Edit)
        [HttpPatch]
        [Route("api/[controller]{id}")]
        public IActionResult EditCliente(int id, Cliente cliente)
        {
            //Checando se o usuário existe
            var clienteAtual = _clienteData.GetCliente(id);

            if (clienteAtual != null)
            {
                cliente.Id = clienteAtual.Id;
                _clienteData.EditCliente(cliente);
            }
            return Ok(cliente);
        }
        */
    }
}
