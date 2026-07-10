using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutores.Apresentacao;

public class InstrutorProfile : Profile
{
    public InstrutorProfile()
    {
        CreateMap<ListarInstrutoresDto, ListarInstrutorViewModel>();
        CreateMap<CadastrarInstrutorViewModel, CadastrarInstrutoresDto>();
        CreateMap<EditarInstrutorViewModel, EditarInstrutoresDto>();
        CreateMap<DetalheInstrutoresDto, EditarInstrutorViewModel>();
        CreateMap<DetalheInstrutoresDto, ExcluirInstrutorViewModel>();
    }
}
