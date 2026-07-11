using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();
        CreateMap<EditarTurmaViewModel, EditarTurmaDto>();
        CreateMap<ListarTurmaDto, ListaTurmaViewModel>();
        CreateMap<DetalhesTurmaDto, EditarTurmaViewModel>();
        CreateMap<DetalhesTurmaDto, ExcluirTurmaViewModel>();
        CreateMap<OpcaoInstrutorDto, OpcaoInstrutorViewModel>();
        CreateMap<OpcaoCursoDto, OpcaoCursoViewModel>();
    }
}