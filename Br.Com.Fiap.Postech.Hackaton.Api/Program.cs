
using Br.Com.Fiap.Postech.Hackaton.Application.Services;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);

            builder.Services.AddDbContext<Context>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            //Dependency Injection
            builder.Services.AddScoped<IMedicoService, MedicoService>();
            builder.Services.AddScoped<IPacienteService, PacienteService>();
            builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();


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
    }
}
