using Aforo255.Cross.Event.Src;
using AFORO255.MS.TEST.Pay.Data;
using AFORO255.MS.TEST.Pay.Messages.CommandHandlers;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Persistences;
using AFORO255.MS.TEST.Pay.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(opt => 
{
    opt.UseMySQL(builder.Configuration["mysql:cn"]);
});
builder.Services.AddScoped<IPaymentServices, PaymentService>();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<IRequestHandler<InvoiceCreatedCommand, bool>, InvoiceCommandHandler>();
builder.Services.AddTransient<IRequestHandler<TransactionCreatedCommand, bool>, TransactionCommandHandler>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();
