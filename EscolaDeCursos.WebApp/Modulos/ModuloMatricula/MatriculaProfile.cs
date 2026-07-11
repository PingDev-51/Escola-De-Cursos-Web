using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class MatriculaProfile : Profile
{
    public MatriculaProfile()
    {
        CreateMap<CadastrarMatriculaViewModel, CadastrarMatriculaDto>();
        CreateMap<ListarMatriculaDto, ListarMatriculaViewModel>();
        CreateMap<DetalhesMatriculaDto, ExcluirMatriculaViewModel>();
        CreateMap<OpcaoAlunoDto, OpcaoAlunoViewModel>();
    }

}