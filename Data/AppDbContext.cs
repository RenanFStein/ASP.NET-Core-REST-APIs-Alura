using FilmesApi.Models;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relacionamento 1:1
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            // Relacionamento 1:n
            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);
            //.OnDelete(DeleteBehavior.Restrict);
            // ou
            //.IsRequired(false);

            builder.Entity<Sessao>()
                    .HasOne(sessao => sessao.Filme)
                    .WithMany(filme => filme.Sessoes)
                    .HasForeignKey(sessao => sessao.FilmeId);
            builder.Entity<Sessao>()
                    .HasOne(sessao => sessao.Cinema)
                    .WithMany(cinema => cinema.Sessoes)
                    .HasForeignKey(sessao => sessao.CinemaId);       
            }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}