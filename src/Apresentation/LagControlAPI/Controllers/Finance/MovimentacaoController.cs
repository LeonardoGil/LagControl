using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Movimentacao")]
    public class MovimentacaoController(IMovimentacaoService financeService, 
                                        IMovimentacaoQuery movimentacaoQuery) : Controller
    {

        #region GET

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar([FromQuery] ListarMovimentacaoQueryModel query)
        {
            try
            {
                return Ok(movimentacaoQuery.ListarMovimentacao(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Listar/Ultimas-Movimentacoes")]
        public IActionResult ListarUltimasMovimentacoes([FromQuery] ListarUltimasMovimentacoesQueryModel query)
        {
            try
            {
                return Ok(movimentacaoQuery.ListarUltimasMovimentacoes(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarMovimentacaoModel request)
        {
            try
            {
                financeService.Adicionar(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Confirmar-Pendente")]
        public IActionResult ConfirmarPendente([FromBody] ConfirmarMovimentacaoPendenteModel request)
        {
            try
            {
                financeService.ConfirmarPendente(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] EditarMovimentaoModel request)
        {
            try
            {
                financeService.Editar(request);

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
                financeService.Excluir(movimentacaoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
