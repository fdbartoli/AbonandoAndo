using AbonandoAndo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]       
    public class ComprobanteController : Controller
    {
        private readonly AbonandoAndo2Context _abonandoAndo2Context;

        public ComprobanteController(AbonandoAndo2Context abonandoAndo2Context)
        {
            _abonandoAndo2Context = abonandoAndo2Context;
        }

        // GET: api/Comprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> Get()
        {
            try
            {
                if (_abonandoAndo2Context.Comprobantes == null)
                {
                    return NotFound();
                }

                return await _abonandoAndo2Context.Comprobantes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Comprobante/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Comprobante>> GetId(int id)
        {
            try
            {
                if (_abonandoAndo2Context.Comprobantes == null)
                {
                    return NotFound();
                }

                var comprobante = await _abonandoAndo2Context.Comprobantes.FindAsync(id);

                if (comprobante == null)
                {
                    return NotFound();
                }

                return comprobante;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // PUT: api/Comprobante/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Comprobante comprobante)
        {

            if (id != comprobante.IdComprobante)
            {
                return BadRequest();
            }

            _abonandoAndo2Context.Entry(comprobante).State = EntityState.Modified;

            try
            {
                await _abonandoAndo2Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                if (!ComprobanteExist(id))
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

        // POST: api/Comprobante

        [HttpPost]

        public async Task<ActionResult<Comprobante>> Create(Comprobante comprobante)
        {
            if (_abonandoAndo2Context == null)
            {
                return Problem("Entity set 'DataContext.Comprobante' is null");
            }
            _abonandoAndo2Context.Comprobantes.Add(comprobante);
            await _abonandoAndo2Context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = comprobante.IdComprobante }, comprobante);
        }

        // DELETE: api/Comprobante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndo2Context.Comprobantes == null)
            {
                return NotFound();
            }
            var comprobante = await _abonandoAndo2Context.Comprobantes.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            _abonandoAndo2Context.Comprobantes.Remove(comprobante);
            await _abonandoAndo2Context.SaveChangesAsync();

            return NoContent();
        }


        private bool ComprobanteExist(int id)
        {
            return (_abonandoAndo2Context.Comprobantes?.Any(e => e.IdComprobante == id)).GetValueOrDefault();
        }
    }
    
}
