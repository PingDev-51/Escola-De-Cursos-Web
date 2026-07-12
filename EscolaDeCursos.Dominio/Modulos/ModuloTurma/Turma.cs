using System.Dynamic;
using System.Globalization;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;

namespace EscolaDeCursos.Dominio.Modulos.ModuloTurma;

public class Turma : EntidadeBase<Turma>
{
    public string Nome { get; set; } = string.Empty;
    public Instrutor? Instrutor { get; set; }
    public string NumeroMaxDeAlunos { get; set; } = string.Empty;
    public Curso? Curso { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }

    Turma() { }

    public Turma(string nome, Curso curso,
    Instrutor instrutor,
    string numeroMaxDeAlunos,
    DateTime dataInicio,
     DateTime dataTermino
     )
    {
        Nome = nome;
        Instrutor = instrutor;
        Curso = curso;
        NumeroMaxDeAlunos = numeroMaxDeAlunos;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
    }

    public override void Atualizar(Turma entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Instrutor = entidadeAtualizada.Instrutor;
        Curso = entidadeAtualizada.Curso;
        NumeroMaxDeAlunos = entidadeAtualizada.NumeroMaxDeAlunos;
        DataInicio = entidadeAtualizada.DataInicio;
        DataTermino = entidadeAtualizada.DataTermino;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(NumeroMaxDeAlunos) || NumeroMaxDeAlunos.Length < 1 || Nome.Length > 100)
            erros.Add("O campo \"Numero Maximo De Alunos\" deve conter entre 1 e 100 Digitos.");

        return erros;
    }
}
