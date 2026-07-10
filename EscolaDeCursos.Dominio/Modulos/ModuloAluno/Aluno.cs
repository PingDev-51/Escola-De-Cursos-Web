using System;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAluno;

public class Aluno : EntidadeBase<Aluno>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public Aluno() { }
    public Aluno(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }

    public override void Atualizar(Aluno entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Email = entidadeAtualizada.Email;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrEmpty(Nome))
            erros.Add("O campo Nome é Obrigatorio;");
        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo Nome deve conter entre 2 a 100 caracteres;");

        if (string.IsNullOrEmpty(Telefone))
            erros.Add("O campo Telefone é Obrigatorio;");
        else if (Telefone.Length != 14)
            erros.Add("O campo Telefone deve conter 14 caracteres;");

        if (string.IsNullOrEmpty(Email))
            erros.Add("O campo Email é Obrigatorio;");

        return erros;
    }
}
