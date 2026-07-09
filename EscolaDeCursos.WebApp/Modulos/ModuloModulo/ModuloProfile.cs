using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModulosCurso;

public class ModuloProfile : Profile
{
    public ModuloProfile()
    {
        CreateMap<ListarModulosDto, ListarModuloViewModel>();
        CreateMap<CadastrarModuloViewModel, CadastrarModulosDto>();
        CreateMap<EditarModuloViewModel, EditarModulosDto>();
        CreateMap<DetalhesModulosDto, EditarModuloViewModel>();
        CreateMap<DetalhesModulosDto, ExcluirModuloViewModel>();
    }
}