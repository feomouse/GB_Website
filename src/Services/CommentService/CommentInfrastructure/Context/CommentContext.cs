using Microsoft.EntityFrameworkCore;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using GB_Project.Services.CommentService.CommentInfrastructrue.EntityConfigurations;

namespace GB_Project.Services.CommentService.CommentInfrastructrue.Context
{
  public class CommentContext : DbContext
  {
    public DbSet<UserComment> UserComments { get; set; }

    public DbSet<ReplyComment> ReplyComments { get; set; }

    public CommentContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Comment;User=sa;Password=107409;",
                                  b => b.MigrationsAssembly("CommentAPI"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserCommentEntityConfiguration());

      modelBuilder.ApplyConfiguration(new ReplyCommentEntityConfiguration());
    }
  }
}