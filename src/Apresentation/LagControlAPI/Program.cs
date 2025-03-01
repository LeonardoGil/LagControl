using LagFinanceApplication.Interfaces;
using LagFinanceApplication.Queries;
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
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("localhost",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                            });

            var app = builder.Build();

            app.UseCors("localhost");

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
            var connectionString = builder.Configuration.GetConnectionString("DbContext") ?? throw new Exception("ConnectionString não localizada");
            builder.Services.AddDbContext<LagFinanceDbContext>(opt => opt.UseSqlServer(connectionString, options => options.MigrationsHistoryTable("__MigrationsHistory", "Finance")));
            builder.Services.AddDbContext<LagDietDbContext>(opt => opt.UseSqlServer(connectionString, options => options.MigrationsHistoryTable("__MigrationsHistory", "diet")));

            builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();

            builder.Services.AddScoped<IContaRepository, ContaRepository>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

            builder.Services.AddScoped<ICategoriaQuery, CategoriaQuery>();
            builder.Services.AddScoped<IContaQuery, ContaQuery>();
            builder.Services.AddScoped<IMovimentacaoQuery, MovimentacaoQuery>();
        }
    }
}
