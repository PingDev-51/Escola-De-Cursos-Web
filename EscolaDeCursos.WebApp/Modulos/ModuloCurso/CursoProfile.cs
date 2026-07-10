using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<CadastrarCursoViewModel, CadastrarCursosDto>();
        CreateMap<EditarCursoViewModel, EditarCursosDto>();

        CreateMap<ListarCursosDto, ListarCursosViewModel>();

        CreateMap<DetalhesCursosDto, EditarCursoViewModel>();
        CreateMap<DetalhesCursosDto, ExcluirCursoViewModel>();

        CreateMap<OpcaoModuloDto, OpcaoModuloViewModel>();
    }

}