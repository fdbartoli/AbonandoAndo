
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
                if (_abonandoAndoContext.Clientes == null)
                {
                    return NotFound();
                }

                return await _abonandoAndoContext.Clientes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
