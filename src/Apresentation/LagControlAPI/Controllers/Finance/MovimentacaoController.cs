using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Movimentacao")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoService _financeService;
        private readonly IMovimentacaoQuery _movimentacaoQuery;

        public MovimentacaoController(IMovimentacaoService financeService, IMovimentacaoQuery movimentacaoQuery)
        {
            _financeService = financeService;
            _movimentacaoQuery = movimentacaoQuery;
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

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] EditarMovimentaoModel request)
        {
            try
            {
                _financeService.Editar(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Excluir/{movimentacaoId}")]
        public IActionResult Excluir([FromRoute] Guid movimentacaoId)
        {
            try
            {
                _financeService.Excluir(movimentacaoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Listar/Ultimas-Movimentacoes")]
        public IActionResult Listar([FromQuery] ListarUltimasMovimentacoesQueryModel query)
        {
            try
            {
                return Ok(_movimentacaoQuery.ListarUltimasMovimentacoes(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
