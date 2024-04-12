using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace PrimeiraAPI.Data
{
    public class MyContext : IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Turma>().ToTable("Turmas");
        }
    }
}
