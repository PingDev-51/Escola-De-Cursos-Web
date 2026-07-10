using System.Dynamic;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCursos;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;
    public Nivel Nivel { get; set; }
    public int CargaHoraria { get; set; }
    public Modulo? Modulo { get; set; }

    public Curso() { }

    public Curso(string nome, Nivel nivel, int cargaHoraria, Modulo? modulo)
    {
        Nome = nome;
        Nivel = nivel;
        CargaHoraria = cargaHoraria;
        Modulo = modulo;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Nivel = entidadeAtualizada.Nivel;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Modulo = entidadeAtualizada.Modulo;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (!Enum.IsDefined(Nivel))
            erros.Add("O campo \"Nivel\" deve ser preenchido.");

        return erros;
    }
}
