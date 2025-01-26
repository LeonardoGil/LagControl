using LagBaseInfra;
using LagDietDomain.Entities;
using LagFinanceInfra.Database;

namespace LagDietInfra.Repositories
{
    public class AlimentoRepository(LagDietDbContext context) : BaseRepository<LagDietDbContext, Alimento>(context)
    {
    }
}
