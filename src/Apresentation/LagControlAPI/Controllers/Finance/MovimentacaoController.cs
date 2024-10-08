﻿using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Movimentacao")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoService _movimentacaoService;
        private readonly IMovimentacaoQuery _movimentacaoQuery;

        public MovimentacaoController(IMovimentacaoService financeService, IMovimentacaoQuery movimentacaoQuery)
        {
            _movimentacaoService = financeService;
            _movimentacaoQuery = movimentacaoQuery;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarMovimentacaoModel request)
        {
            try
            {
                _movimentacaoService.Adicionar(request);

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
                _movimentacaoService.ConfirmarPendente(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] EditarMovimentaoModel request)
        {
            try
            {
                _movimentacaoService.Editar(request);

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
                _movimentacaoService.Excluir(movimentacaoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar([FromQuery] ListarMovimentacaoQueryModel query)
        {
            try
            {
                return Ok(_movimentacaoQuery.ListarMovimentacao(query));
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
                return Ok(_movimentacaoQuery.ListarUltimasMovimentacoes(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
