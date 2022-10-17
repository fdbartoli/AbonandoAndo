using AbonandoAndo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AbonandoAndo2Context _abonandoAndo2Context;

        public EmpresaController(AbonandoAndo2Context abonandoAndo2Context)
        {
            _abonandoAndo2Context = abonandoAndo2Context;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {
            try
            {
                if (_abonandoAndo2Context.Empresas == null)
                {
                    return NotFound();
                }

                return await _abonandoAndo2Context.Empresas.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Empresa>> GetId(int id)
        {
            try
            {
                if (_abonandoAndo2Context.Empresas == null)
                {
                    return NotFound();
                }

                var empresa = await _abonandoAndo2Context.Empresas.FindAsync(id);

                if (empresa == null)
                {
                    return NotFound();
                }

                return empresa;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, Empresa empresa)
        {

            if (id != empresa.IdEmpresa)
            {
                return BadRequest();
            }

            _abonandoAndo2Context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _abonandoAndo2Context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                if (!EmpresaExist(id))
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

        // POST: api/Empresa

        [HttpPost]

        public async Task<ActionResult<Empresa>> Create(Empresa empresa)
        {
            if (_abonandoAndo2Context == null)
            {
                return Problem("Entity set 'DataContext.Empresa' is null");
            }
            _abonandoAndo2Context.Empresas.Add(empresa);
            await _abonandoAndo2Context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = empresa.IdEmpresa }, empresa);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_abonandoAndo2Context.Empresas == null)
            {
                return NotFound();
            }
            var empresa = await _abonandoAndo2Context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _abonandoAndo2Context.Empresas.Remove(empresa);
            await _abonandoAndo2Context.SaveChangesAsync();

            return NoContent();
        }


        private bool EmpresaExist(int id)
        {
            return (_abonandoAndo2Context.Empresas?.Any(e => e.IdEmpresa == id)).GetValueOrDefault();
        }

    }
}
