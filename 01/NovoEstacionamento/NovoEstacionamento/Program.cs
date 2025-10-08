using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovoEstacionamento.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((Context,services) =>
    {
        string connection = "Server=(localdb)\\mssqllocaldb;Database=NovoEstacionamentoDB;Trusted_Connection=True;";
         
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
    })
    .Build();
