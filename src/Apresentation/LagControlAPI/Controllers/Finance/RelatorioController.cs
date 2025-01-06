using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Contas;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Relatorio")]
    public class RelatorioController(IContaQuery _contaQuery) : Controller
    {
        [HttpGet]
        [Route("Extrato")]
        public IActionResult Extrato([FromQuery] ExtratoQueryModel query)
        {
            try
            {
                return Ok(_contaQuery.Extrato(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Despesas-por-categoria")]
        public IActionResult DespesasPorCategoria([FromQuery] DespesasPorCategoriaQueryModel query)
        {
            try
            {
                return Ok(_contaQuery.DespesasPorCategoria(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
