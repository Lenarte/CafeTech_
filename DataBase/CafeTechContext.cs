using Microsoft.EntityFrameworkCore;

class CafeTechContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(
            "server=localhost;port=3306;database=paulo;user=root;password=paulo6310");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasKey(s => s.IdProduto);

        modelBuilder.Entity<Funcionario>()
            .HasKey(f => f.IdFuncionario);

        modelBuilder.Entity<Cliente>()
            .HasKey(c => c.IdCliente);

    }

    public CafeTechContext(DbContextOptions<CafeTechContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    
}