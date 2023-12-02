using AutoMapper;
using LagControlForms.Models;
using LagFinanceLib.Domain;

namespace LagControlForms.Profiles
{
    public class MovimentacaoModelProfile : Profile
    {
        public MovimentacaoModelProfile()
        {
            var movimentacaoMap = CreateMap<Movimentacao, MovimentacaoModel>();

            movimentacaoMap.ForMember(mov => mov.Categoria, model => model.MapFrom(m => m.Categoria.Descricao))
                           .ForMember(mov => mov.Conta, model => model.MapFrom(m => m.Conta.Descricao));

            movimentacaoMap.ReverseMap();
        }
    }
}
