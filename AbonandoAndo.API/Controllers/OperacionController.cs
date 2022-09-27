using AbonandoAndo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AbonandoAndo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly AbonandoAndo2Context _abonandoAndo2Context;

        public OperacionController(AbonandoAndo2Context abonandoAndo2Context)
        {
            _abonandoAndo2Context = abonandoAndo2Context;
        }

        // GET: api/Operacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacion>>> Get()
        {
            try
            {
                if (_abonandoAndo2Context.Operacions == null)
                {
                    return NotFound();
                }

                return await _abonandoAndo2Context.Operacions.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Operacion/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Operacion>> GetId(int id)
        {
            try
            {
                if (_abonandoAndo2Context.Operacions == null)
                {
                    return NotFound();
                }

                var operacion = await _abonandoAndo2Context.Operacions.FindAsync(id);

                if (operacion == null)
                {
                    return NotFound();
                }

                return operacion;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // PUT: api/Operacion/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Operacion operacion)
        {

            if (id != operacion.IdOperacion)
            {
                return BadRequest();
            }

            _abonandoAndo2Context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _abonandoAndo2Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                if (!OperacionExist(id))
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

        // POST: api/Operacion

        [HttpPost]

        public async Task<ActionResult<Operacion>> Create(Operacion operacion)
        {
            if (_abonandoAndo2Context == null)
            {
                return Problem("Entity set 'DataContext.Operacion' is null");
            }
            _abonandoAndo2Context.Operacions.Add(operacion);
            await _abonandoAndo2Context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = operacion.IdOperacion }, operacion);
        }

        // DELETE: api/Operacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndo2Context.Operacions == null)
            {
                return NotFound();
            }
            var operacion = await _abonandoAndo2Context.Operacions.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }

            _abonandoAndo2Context.Operacions.Remove(operacion);
            await _abonandoAndo2Context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacionExist(int id)
        {
            return (_abonandoAndo2Context.Operacions?.Any(e => e.IdOperacion == id)).GetValueOrDefault();
        }

    }
}
