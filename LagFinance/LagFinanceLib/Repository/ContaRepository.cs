﻿using LagFinanceLib.Database;
using LagFinanceLib.Domain;
using LagFinanceLib.Interfaces;

namespace LagFinanceLib.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(LagFinanceDbContext context)
        {
            _context = context;
        }
    }
}
