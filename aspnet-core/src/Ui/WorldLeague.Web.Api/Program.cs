using WorldLeague.EntityFrameworkCore.PostgreSQL.Extensions;
using WorldLeague.EntityFrameworkCore.PostgreSQL.DIs;
using WorldLeague.Application.DIs;
using WorldLeague.Web.Api.Routers.Leagues;
using WorldLeague.Web.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddEntityFrameworkCore()
    .AddUnitOfWork()
    .AddRepositories();

builder.Services.AddMediatR()
    .AddAutoMapper();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.MapLeagueRoutes();
app.Run();
