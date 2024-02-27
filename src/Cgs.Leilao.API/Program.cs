using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Filters;
using Cgs.Leilao.API.Repositories;
using Cgs.Leilao.API.Repositories.DataAccess;
using Cgs.Leilao.API.Services;
using Cgs.Leilao.API.UseCases.Leiloes.GetCurrent;
using Cgs.Leilao.API.UseCases.Offers.CreateOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });


        builder.Services.AddScoped<AutenticationUserAttribute>();
        builder.Services.AddScoped<ILoggedUser, LoggedUser>();
        builder.Services.AddScoped<CreateOfferUseCase>();
        builder.Services.AddScoped<GetCurrentAuctionUseCases>();
        builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
        builder.Services.AddScoped<IOfferRepository, OfferRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddDbContext<CgsLeilaoDbContext>(options =>
        {
            options.UseSqlite(@"Data Source=C:\Users\Marcos\source\repos\Cgs.Leilao\db\leilaoDbNLW.db");
        });


        builder.Services.AddHttpContextAccessor();

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