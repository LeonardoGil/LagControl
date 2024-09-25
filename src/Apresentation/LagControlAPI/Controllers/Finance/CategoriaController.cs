using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaQuery categoriaQuery, 
                                   ICategoriaService categoriaService)
        {
            _categoriaQuery = categoriaQuery;
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarCategoriaModel model)
        {
            try
            {
                _categoriaService.Adicionar(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_categoriaQuery.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
