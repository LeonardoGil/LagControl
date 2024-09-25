using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace LagControlAPI.Controllers.Finance
{
    [Route("Categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaQuery _categoriaQuery;

        public CategoriaController(ICategoriaQuery categoriaQuery)
        {
            _categoriaQuery = categoriaQuery;
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
