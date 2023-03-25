using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.Messages.EventHandlers;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Persistences;
using AFORO255.MS.TEST.Transaction.Persistences.Settings;
using AFORO255.MS.TEST.Transaction.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

builder.Services.AddControllers();
builder.Services.Configure<Mongosettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("cn:mongo").Value;
    opt.DatabaseName = builder.Configuration.GetSection("mongo:database").Value;
});
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();
builder.Services.AddConsul();
builder.Services.AddFabio();

builder.Services.AddTransient<TransactionEventHandler>();
builder.Services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();

var app = builder.Build();

app.UseAuthorization();

ConfigureEventBus(app);

app.MapControllers();

app.UseConsul();

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
}
