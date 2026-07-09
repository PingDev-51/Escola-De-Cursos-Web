namespace EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Dominio.Compartilhado;

public class Modulo : EntidadeBase<Modulo>
{
    public string Nome { get; set; } = string.Empty;
    public int Duracao { get; set; }

    public Modulo()
    {
    }

    public Modulo(string nome, int duracao) : this()
    {
        Nome = nome;
        Duracao = duracao;
    }

    public override void Atualizar(Modulo entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Duracao = entidadeAtualizada.Duracao;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        return erros;
    }
}
