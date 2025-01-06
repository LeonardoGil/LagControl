using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Contas;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [Route("Listar/Saldo")]
        public IActionResult Saldo([FromQuery] ContaSaldoQueryModel query)
        {
            try
            {
                return Ok(_contaQuery.ListarSaldo(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
