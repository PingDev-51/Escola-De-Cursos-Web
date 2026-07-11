using System.Runtime.InteropServices;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public class Matricula : EntidadeBase<Matricula>
{
    public Aluno? Aluno { get; set; }
    public Turma? Turma { get; set; }
    public Guid MatriculaId {get; set;} = Guid.CreateVersion7();

    Matricula() { }

    public Matricula(Aluno aluno, Turma turma)
    {
        Aluno = aluno;
        Turma = turma;
        MatriculaId = Guid.CreateVersion7();
    }

    public override void Atualizar(Matricula entidadeAtualizada)
    {
        Aluno = entidadeAtualizada.Aluno;
        Turma = entidadeAtualizada.Turma;
        MatriculaId = entidadeAtualizada.MatriculaId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Aluno == null)
            erros.Add("O aluno é obrigatório.");
        return erros;
    }
}