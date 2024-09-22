using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LagControlAPI.Controllers
{
    public class FinanceController : Controller
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpPost]
        [Route("Movimentacao/Adicionar")]
        public IActionResult Add([FromBody] AddMovimentacaoModel request)
        {
            try
            {
                _financeService.AddMovimentacao(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
