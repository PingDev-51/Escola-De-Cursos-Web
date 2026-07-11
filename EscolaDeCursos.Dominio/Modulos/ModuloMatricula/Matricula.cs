using System.Runtime.InteropServices;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;

namespace EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public class Matricula : EntidadeBase<Matricula>
{
    public Aluno? Aluno { get; set; }
    public Guid MatriculaId {get; set;}

    Matricula() {}

    public Matricula(Aluno aluno, Curso curso, Guid matriculaId)
    {
        Aluno = aluno;
        MatriculaId = matriculaId;
    }

    public override void Atualizar(Matricula entidadeAtualizada)
    {
        Aluno = entidadeAtualizada.Aluno;
        MatriculaId = entidadeAtualizada.MatriculaId;
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}