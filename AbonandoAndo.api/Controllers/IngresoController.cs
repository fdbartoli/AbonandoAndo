using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbonandoAndo.api.Models;
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


        // post: api/Ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> Get()
        {
            try
            {
                var result = await _abonandoAndoContext.Egresos.FromSqlInterpolated($"exec select_all_cliente").ToListAsync();

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

    }
}

