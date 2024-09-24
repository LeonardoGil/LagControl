
using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Services;
using LagFinanceInfra.Database;
using LagFinanceInfra.Interfaces;
using LagFinanceInfra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LagControlAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            DependencyInjection(builder);
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(@"Data Source=localhost;Initial Catalog=LagControl;Persist Security Info=True;User ID=sa;Password=P@ssw0rd!;Connect Timeout=900;TrustServerCertificate=true"));

            builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();

            builder.Services.AddScoped<IContaRepository, ContaRepository>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        }
    }
}
