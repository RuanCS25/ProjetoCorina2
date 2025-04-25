namespace ProjetoCorina2.Models
{
    public class RegistroAusencia
    {
        public Guid RegistroAusenciaId { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public DateTime? Data { get; set; }
        public string Refeicao { get; set; }
    }
}
