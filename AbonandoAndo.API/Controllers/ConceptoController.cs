using AbonandoAndo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        private readonly AbonandoAndo2Context _abonandoAndo2Context;

        public ConceptoController(AbonandoAndo2Context abonandoAndo2Context)
        {
            _abonandoAndo2Context = abonandoAndo2Context;
        }

        // GET: api/Concepto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concepto>>> Get()
        {
            try
            {
                if (_abonandoAndo2Context.Conceptos == null)
                {
                    return NotFound();
                }

                return await _abonandoAndo2Context.Conceptos.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Concepto/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Concepto>> GetId(int id)
        {
            try
            {
                if (_abonandoAndo2Context.Conceptos == null)
                {
                    return NotFound();
                }

                var concepto = await _abonandoAndo2Context.Conceptos.FindAsync(id);

                if (concepto == null)
                {
                    return NotFound();
                }

                return concepto;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // PUT: api/Concepto/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Concepto concepto)
        {

            if (id != concepto.IdConcepto)
            {
                return BadRequest();
            }

            _abonandoAndo2Context.Entry(concepto).State = EntityState.Modified;

            try
            {
                await _abonandoAndo2Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                if (!ConceptoExist(id))
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

        // POST: api/Concepto

        [HttpPost]

        public async Task<ActionResult<Concepto>> Create(Concepto concepto)
        {
            if (_abonandoAndo2Context == null)
            {
                return Problem("Entity set 'DataContext.Concepto' is null");
            }
            _abonandoAndo2Context.Conceptos.Add(concepto);
            await _abonandoAndo2Context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = concepto.IdConcepto }, concepto);
        }

        // DELETE: api/Concepto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndo2Context.Conceptos == null)
            {
                return NotFound();
            }
            var concepto = await _abonandoAndo2Context.Conceptos.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            _abonandoAndo2Context.Conceptos.Remove(concepto);
            await _abonandoAndo2Context.SaveChangesAsync();

            return NoContent();
        }


        private bool ConceptoExist(int id)
        {
            return (_abonandoAndo2Context.Conceptos?.Any(e => e.IdConcepto == id)).GetValueOrDefault();
        }

    }
}

