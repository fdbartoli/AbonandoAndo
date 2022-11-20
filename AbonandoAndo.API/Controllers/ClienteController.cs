
using AbonandoAndo.api.Models;
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

        //GET: api/Cliente/5
        [HttpGet("{cuil}")]

        public async Task<ActionResult<Cliente>> GetIngresoCuil(string cuil)
        {

            try
            {
                if (_abonandoAndoContext.Clientes == null)
                {
                    return NotFound();
                }

                var result = await _abonandoAndoContext.Clientes.FromSqlInterpolated($"select_cliente_egreso_cuil @cuil = {cuil}").ToListAsync();

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
