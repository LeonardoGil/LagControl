using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Models.Movimentacoes;
using LagFinanceDomain.Domain;
using LagFinanceInfra.Interfaces;

namespace LagFinanceApplication.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public void Adicionar(AdicionarMovimentacaoModel model)
        {
            var movimentacao = new Movimentacao
            {
                CategoriaId = model.CategoriaId,
                ContaId = model.ContaId,

                Valor = model.Valor,
                Descricao = model.Descricao,
                Observacao = model.Observacao,
                Data = model.Data,

                TipoMovimentacao = model.Tipo,
                Pendente = model.Pendente
            };

            _movimentacaoRepository.Add(movimentacao);
            _movimentacaoRepository.SaveChanges();
        }

        public void Editar(EditarMovimentaoModel model)
        {
            var movimentacao = _movimentacaoRepository.Get().FirstOrDefault(x => x.Id == model.Id) ?? throw new Exception("Movimentação não encontrada");

            movimentacao.Descricao = model.Descricao;
            movimentacao.Observacao = model.Observacao;
            movimentacao.Valor = model.Valor;
            movimentacao.Data = model.Data;
            movimentacao.Pendente = model.Pendente;
            movimentacao.ContaId = model.ContaId;
            movimentacao.CategoriaId = model.CategoriaId;

            _movimentacaoRepository.SaveChanges();
        }

        public void Excluir(Guid movimentacaoId)
        {
            var movimentacao = _movimentacaoRepository.Get().FirstOrDefault(x => x.Id == movimentacaoId) ?? throw new Exception("Movimentação não encontrada");

            _movimentacaoRepository.Remove(movimentacao);
            _movimentacaoRepository.SaveChanges();
        }
    }
}
