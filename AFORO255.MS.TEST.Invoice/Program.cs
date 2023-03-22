using AFORO255.MS.TEST.Invoice.Data;
using AFORO255.MS.TEST.Invoice.Persistences;
using AFORO255.MS.TEST.Invoice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(opt =>
{
    opt.UseNpgsql(builder.Configuration["postgres:cn"]);
});
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();
