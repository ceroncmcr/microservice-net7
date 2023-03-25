using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Data;
using AFORO255.MS.TEST.Invoice.Messages.EventHandlers;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using AFORO255.MS.TEST.Invoice.Persistences;
using AFORO255.MS.TEST.Invoice.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(opt =>
{
    opt.UseNpgsql(builder.Configuration["postgres:cn"]);
});
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<InvoiceEventHandler>();
builder.Services.AddTransient<IEventHandler<InvoiceCreatedEvent>, InvoiceEventHandler>();

var app = builder.Build();

app.UseAuthorization();

DbCreated.CreateDbIfNotExists(app);

ConfigureEventBus(app);

app.MapControllers();

app.Run();


void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<InvoiceCreatedEvent, InvoiceEventHandler>();
}
