using Microsoft.Extensions.DependencyInjection;
using GB_Project.Services.CommentService.CommentInfrastructrue.Context;
using GB_Project.Services.CommentService.CommentDomin.AggregateModel;
using GB_Project.Services.CommentService.CommentInfrastructrue.Repository;
using Microsoft.EntityFrameworkCore;

namespace GB_Project.Services.CommentService.UnitTest.InfrastructureUnitTest
{
  public class BasicConfig
  {
    public CommentRepository repository { get; set; }

    private ServiceCollection services;

    public BasicConfig()
    {
      string connectionString = "Server=DESKTOP-FF3NFIK\\SQLEXPRESS;Database=Comment;User=sa;Password=107409;";
      services= new ServiceCollection();

      services.AddEntityFrameworkSqlServer().AddDbContext<CommentContext>((lprovider, options) => {
        options.UseSqlServer(connectionString)
               .UseInternalServiceProvider(lprovider);
      });
 
      var provider = services.BuildServiceProvider();

      var context = provider.GetService<CommentContext>();

      context.UserComments = context.Set<UserComment>();
      context.ReplyComments = context.Set<ReplyComment>();

      repository = new CommentRepository(context);
    }
  }
}