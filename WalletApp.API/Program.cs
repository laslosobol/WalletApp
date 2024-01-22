using Microsoft.EntityFrameworkCore;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Mappers;
using WalletApp.BLL.Services;
using WalletApp.DAL.Context;
using WalletApp.DAL.Interfaces;
using WalletApp.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "Host=localhost;Port=5432;Database=testTask;User Id=postgres;Password=sobol;";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<UserMapper>();
builder.Services.AddSingleton<CardMapper>();
builder.Services.AddSingleton<TransactionMapper>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IWalletAppService, WalletAppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseHttpsRedirection();

app.MapControllers();

app.Run();