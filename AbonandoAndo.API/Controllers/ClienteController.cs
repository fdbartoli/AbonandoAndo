using AbonandoAndo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AbonandoAndo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AbonandoAndo2Context _abonandoAndo2Context;

        public ClienteController(AbonandoAndo2Context abonandoAndo2Context)
        {
            _abonandoAndo2Context = abonandoAndo2Context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            try { 
                if (_abonandoAndo2Context.Clientes == null)
                {
                    return NotFound();
                }

                return await _abonandoAndo2Context.Clientes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Cliente>> GetId(int id)
        {
            try
            {
                if (_abonandoAndo2Context.Clientes == null)
                {
                    return NotFound();
                }

                 var cliente = await _abonandoAndo2Context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Cliente cliente)
        {

            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _abonandoAndo2Context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _abonandoAndo2Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                if (!ClienteExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new DbUpdateConcurrencyException(e.Message);
                }
            }

            return NoContent();

        }

        // POST: api/Cliente

        [HttpPost]

        public async Task <ActionResult<Cliente>> Create(Cliente cliente)
        {
            if (_abonandoAndo2Context == null)
            {
                return Problem("Entity set 'DataContext.Cliente' is null");
            }
            _abonandoAndo2Context.Clientes.Add(cliente);
            await _abonandoAndo2Context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cliente.IdCliente }, cliente);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndo2Context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _abonandoAndo2Context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _abonandoAndo2Context.Clientes.Remove(cliente);
            await _abonandoAndo2Context.SaveChangesAsync();

            return NoContent();
        }


        private bool ClienteExist(int id)
        {
            return (_abonandoAndo2Context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }

    }
}
