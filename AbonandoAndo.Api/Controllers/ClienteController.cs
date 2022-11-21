
using AbonandoAndo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {


        private readonly AbonandoAndoContext _abonandoAndoContext;

        public ClienteController(AbonandoAndoContext abonandoAndoContext)
        {
            _abonandoAndoContext = abonandoAndoContext;
        }


        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            try
            {
                var result = await _abonandoAndoContext.Clientes.FromSqlInterpolated($"exec select_all_cliente").ToListAsync();

                return Ok(result);
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
                if (_abonandoAndoContext.Clientes == null)
                {
                    return NotFound();
                }

                var cliente = await _abonandoAndoContext.Clientes.FindAsync(id);

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

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _abonandoAndoContext.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _abonandoAndoContext.SaveChangesAsync();
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

        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            if (_abonandoAndoContext == null)
            {
                return Problem("Entity set 'DataContext.Cliente' is null");
            }
            _abonandoAndoContext.Clientes.Add(cliente);
            await _abonandoAndoContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndoContext.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _abonandoAndoContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _abonandoAndoContext.Clientes.Remove(cliente);
            await _abonandoAndoContext.SaveChangesAsync();

            return NoContent();
        }


        private bool ClienteExist(int id)
        {
            return (_abonandoAndoContext.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
