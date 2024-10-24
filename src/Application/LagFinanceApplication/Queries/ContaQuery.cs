﻿using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Contas;
using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Enum;
using LagFinanceInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LagFinanceApplication.Queries
{
    public class ContaQuery : IContaQuery
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ContaQuery(IContaRepository contaRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _contaRepository = contaRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public IList<ContaSaldoModel> ListarSaldo(ContaSaldoQueryModel model)
        {
            var contas = _contaRepository.Get().AsNoTracking();

            if (model.ContaIds is not null && model.ContaIds.Any())
                contas = contas.Where(x => model.ContaIds.Contains(x.Id));

            return [.. contas.Include(x => x.Movimentacoes)
                             .Select(conta => new ContaSaldoModel
                             {
                                 Descricao = conta.Descricao,
                                 Saldo = conta.Saldo()
                             })];
        }

        public IList<ContaListaModel> Listar()
        {
            var conta = _contaRepository.Get().AsNoTracking();

            return [.. conta.Select(conta => new ContaListaModel
            {
                Id = conta.Id,
                Descricao = conta.Descricao
            })];
        }

        public ExtratoModel Extrato(ExtratoQueryModel query)
        {
            var conta = _contaRepository.Get()
                                        .Include(x => x.Movimentacoes).ThenInclude(x => x.Categoria)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == query.ContaId) ?? throw new NotImplementedException($"Conta '{query.ContaId}' não encontrada");

            if (!conta.Movimentacoes.Any())
                throw new Exception("Conta não possui Movimentações");

            var dataInicio = query.DataInicio ?? new DateOnly(2024, 01, 01);
            var dataFim = query.DataFim ?? DateOnly.FromDateTime(DateTime.Now);

            var valorSaldoAnterior = conta.Movimentacoes.Where(x => DateOnly.FromDateTime(x.Data) < dataInicio)  
                                                   .Where(x => !x.Pendente)
                                                   .Sum(x => x.ValorSaldo());

            var movimentacoes = conta.Movimentacoes.Where(x => DateOnly.FromDateTime(x.Data) >= dataInicio)
                                                   .Where(x => DateOnly.FromDateTime(x.Data) <= dataFim)
                                                   .ToList();

            return new ExtratoModel(conta.Descricao, movimentacoes, dataInicio, dataFim, valorSaldoAnterior);
        }

        public DespesasPorCategoriaModel DespesasPorCategoria(DespesasPorCategoriaQueryModel query)
        {
            var conta = _contaRepository.Get()
                                        .Include(x => x.Movimentacoes).ThenInclude(x => x.Categoria)
                                        .AsNoTracking()
                                        .FirstOrDefault(x => x.Id == query.ContaId) ?? throw new NotImplementedException($"Conta '{query.ContaId}' não encontrada");

            var despesasPorCategoria = new DespesasPorCategoriaModel(conta);

            return despesasPorCategoria;
        }
    }
}
