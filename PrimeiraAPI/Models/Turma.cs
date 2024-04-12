using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPI.Models
{
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }
        public string TurmaName { get; set; }
    }
}
