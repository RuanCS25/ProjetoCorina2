namespace ProjetoCorina2.Models
{
    public class RegPresenca
    {
        public Guid RegPresencaId { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno? Alunos { get; set; }
        public string DataPresenca { get; set; }
        public string Refeicao { get; set; }
    }
}
