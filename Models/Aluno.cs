
namespace ProjetoCorina2.Models
{
    public class Aluno
    {
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string CPF { get; set; }

        public Guid ClassificacoeId { get; set; }

        public Classificacoe? Classificacoe { get; set; }

        public Guid HorarioId { get; set; }

        public Horario? Horario { get; set; }

        public string? Senha { get; set; }
    }
}
