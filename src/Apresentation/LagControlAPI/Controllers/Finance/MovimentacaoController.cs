using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Movimentacao")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoService _financeService;

        public MovimentacaoController(IMovimentacaoService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarMovimentacaoModel request)
        {
            try
            {
                _financeService.Adicionar(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
