namespace ProjetoCorina2.Models
{
    public class Aviso
    {
        public Guid AvisoId { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        public string Descricao { get; set; }
       
    }
}
