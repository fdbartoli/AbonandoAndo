using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbonandoAndo.api.Models;
using Microsoft.EntityFrameworkCore;

namespace AbonandoAndo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresoController : ControllerBase
    {

        private readonly AbonandoAndoContext _abonandoAndoContext;

        public EgresoController(AbonandoAndoContext abonandoAndoContext)
        {
            _abonandoAndoContext = abonandoAndoContext;
        }


        // GET: api/Egreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Egreso>>> Get()
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

        //GET: api/Egreso/5
        [HttpGet("{cuil}")]

        public async Task<ActionResult<Egreso>> GetEgresoCuil(string cuil)
        {

            try
            {
                if (_abonandoAndoContext.Egresos == null)
                {
                    return NotFound();
                }

                var result = await _abonandoAndoContext.Egresos.FromSqlInterpolated($"select_cliente_egreso_cuil @cuil = {cuil}").ToListAsync();

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

