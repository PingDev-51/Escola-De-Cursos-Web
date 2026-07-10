using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<ListarAlunosDto, ListarAlunosViewModel>();
        CreateMap<CadastrarAlunosViewModel, CadastrarAlunosDto>();
        CreateMap<EditarAlunosViewModel, EditarAlunosDto>();

        CreateMap<DetalhesAlunosDto, EditarAlunosViewModel>();
        CreateMap<DetalhesAlunosDto, ExcluirAlunosViewModel>();
    }
}
