using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<ListarTurmaDto, ListaTurmaViewModel>();
    }
}