using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPI.Models
{
    public class Aluno
    {
        [Required]
        [Key]
        public int AlunoId { get; set; }
        [Required]
        public string AlunoName { get; set; }
        [Required]

        public string AlunoRM { get; set; }

        //Relacionamentoi com a tabela turma
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
