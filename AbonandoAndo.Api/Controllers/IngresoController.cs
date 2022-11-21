using AbonandoAndo.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AbonandoAndo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {

        private readonly AbonandoAndoContext _abonandoAndoContext;

        public IngresoController(AbonandoAndoContext abonandoAndoContext)
        {
            _abonandoAndoContext = abonandoAndoContext;
        }


        // get: api/Ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> Get()
        {
            try
            {
                var result = await _abonandoAndoContext.Egresos.FromSqlInterpolated($"exec select_all_ingreso").ToListAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //get: api/Ingreso/5
        [HttpGet("{cuil}")]

        public async Task<ActionResult<Ingreso>> GetIngresoCuil(string cuil)
        {

            try
            {
                if (_abonandoAndoContext.Egresos == null)
                {
                    return NotFound();
                }

                var result = await _abonandoAndoContext.Ingresos.FromSqlInterpolated($"select_cliente_ingreso_cuil @cuil = {cuil}").ToListAsync();

                var resultTemp = result.ToString();
                if (result.Count == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        // POST: api/Ingreso

        [HttpPost]

        public async Task<ActionResult<Ingreso>> Create(Ingreso ingreso)
        {
            if (_abonandoAndoContext == null)
            {
                return Problem("Entity set 'DataContext.Ingreso' is null");
            }
            _abonandoAndoContext.Ingresos.Add(ingreso);
            await _abonandoAndoContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = ingreso.Id }, ingreso);
        }


    }
}

