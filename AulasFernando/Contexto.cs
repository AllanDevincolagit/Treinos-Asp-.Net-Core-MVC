namespace AulasFernando {
    using Microsoft.EntityFrameworkCore;
    using AulasFernando.Entidades;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Usuarios> USUARIOS { get; set; }
        public DbSet<Profissoes> PROFISSOES { get; set; }
        public DbSet<Formacao> FORMACAO { get; set; }
    }
}


    

