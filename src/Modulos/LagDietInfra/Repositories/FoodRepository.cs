using LagBaseInfra;
using LagDietDomain.Entities;
using LagDietInfra.Database;

namespace LagDietInfra.Repositories
{
    public class FoodRepository(LagDietDbContext context) : BaseRepository<LagDietDbContext, Food>(context)
    {
    }
}

