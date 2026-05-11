using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Gamesendpoints;
using GameStore.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");

builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["Authentication:Schemes:Bearer:SigningKeys:0:Value"];
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Schemes:Bearer:ValidIssuer"],
            ValidAudiences = builder.Configuration.GetSection("Authentication:Schemes:Bearer:ValidAudiences").Get<string[]>(),
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(key!))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/")
   .MapGameEndpoints();

app.Run();