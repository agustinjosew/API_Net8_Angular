using Microsoft.OpenApi.Models;
using System.Reflection;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using GestionRecursosHumanos.API.Databases;
using GestionRecursosHumanos.API.Mappings;
using GestionRecursosHumanos.API.Services.Interfaces;
using GestionRecursosHumanos.API.Services;
using GestionRecursosHumanos.API.Repositories.Interfaces;
using GestionRecursosHumanos.API.Repositories;

namespace GestionRecursosHumanos.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<MongoDBSettings>(
                builder.Configuration.GetSection("MongoDB"));

            builder.Services.AddSingleton<IMongoClient>(
                ServiceProvider =>
            {
                var settings = ServiceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            builder.Services.AddScoped<IMongoDatabase>(
                ServiceProvider =>
            {
                var settings = ServiceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                var client = ServiceProvider.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });
            builder.Services.AddAutoMapper(typeof(PerfilDeMapeo));

            builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
            builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1", new OpenApiInfo
                    {
                        Title = "Mi API",
                        Version = "v1",
                        Description = "Gesti�n de recursos humanos, dise�ada para facilitar la administraci�n eficiente de empleados, candidatos, puestos, departamentos, y gesti�n de vacaciones y ausencias. ",
                        Contact = new OpenApiContact
                        {
                            Name = "Agustin Jose Wawrzyk",
                            Email = "Test",
                            Url = new Uri("https://soundcloud.com/awakenings/awakenings-spring-festival-2023-bart-skills")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Licencia API",
                            Url = new Uri("https://api.com/licencia")
                        }
                    });

                // Configuraci�n para JWT en Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor, inserte el token JWT con 'Bearer ' prefijo",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                // Habilitar anotaciones XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Filtros personalizados
                // ...

            });

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