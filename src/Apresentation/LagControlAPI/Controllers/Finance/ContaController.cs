using LagFinanceApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Conta")]
    public class ContaController : Controller
    {
        private readonly IContaQuery _contaQuery;

        public ContaController(IContaQuery contaQuery)
        {
            _contaQuery = contaQuery;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_contaQuery.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Saldo/{contaId}")]
        public IActionResult Saldo([FromRoute] Guid contaId)
        {
            try
            {
                return Ok(_contaQuery.ConsultarSaldo(contaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
